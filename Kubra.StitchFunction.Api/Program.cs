using System.ServiceModel;
using Kubra.Common;
using Kubra.Common.Helpers;
using Kubra.Common.Observability.Extensions;
using Kubra.Common.Stitch.Extensions;
using Kubra.Common.WebApi.Extensions;
using Kubra.StitchFunction.Api.Config;
using Kubra.StitchFunction.Api.HealthCheck;
using Kubra.StitchFunction.Api.Services;
using MockClientSOAPService;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.
// IMPORTANT: Always configure your logging first!
builder.Services.AddKubraOpenTelemetry(configuration);
builder.Services.AddHttpClient();
builder.Services.AddControllers(options => options.AddKubraResponseCacheProfiles().EnableEndpointRouting = false);

#region Sidecar
builder.Services.AddStitchSecretsService(configuration);
builder.Services.AddSingleton<IClientConfigProvider, ContextConfigProvider>();
#endregion

#region Services
//Only one of these should be implemented per stitch function
//If adding a SOAP service, use scoped
builder.Services.AddSingleton<IBalanceService, RestBalanceService>();
builder.Services.AddSingleton<IPostPaymentService, RestPostPaymentService>();
builder.Services.AddScoped<ISoapService>(sp =>
{
    var config = sp.GetRequiredService<IClientConfigProvider>();
    EndpointAddress endpoint = new(new Uri(config.GetConfig().Result.WebServiceUrl));
    return new SoapServiceClient(SoapServiceClient.EndpointConfiguration.BasicHttpBinding_ISoapService_soap, endpoint);
});
#endregion


#region HealthChecks
builder.Services.AddHealthChecks()
    .AddCheck<LivenessHealthCheck>(name: "Liveness Health check", tags: new[] { "liveness" })
    .AddCheck<ReadinessHealthCheck>(name: "Readiness Health check", tags: new[] { "readiness" });
#endregion
var app = builder.Build();

var tracerProvider = app.Services.GetRequiredService<TracerProvider>();

app.UseRouting();
app.UseKubraExceptionHandler(app.Environment);
app.UseKubraUnauthorizedHandler();
app.UseKubraForbiddenHandler();
app.UseHttpsRedirection();
app.MapControllers();
app.UseCors(corsBuilder => corsBuilder
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin());
app
    // Liveness - Check whether the application that runs in the container, is not in an unresponsive state.
    .MapKubraHealthCheck(pattern: "/actuator/health/live",
        healthCheckPredicate: hc => hc.Tags.Contains("liveness"))
    .MapKubraHealthCheck(pattern: "/actuator/health/ready",
        healthCheckPredicate: hc => hc.Tags.Contains("readiness"));

//Structure here is important to pick up failed startup attempts in the logger.
try
{
    using (var activity = ActivitySourceHelper.ApplicationActivitySource.StartActivity(ActivitySourceHelper.ApplicationActivitySource.Name))
    {
        try
        {
            await app.StartAsync();
        }
        catch (Exception ex)
        {
            Log.Logger.LogError(ex, "This is from startup");
            activity?.RecordException(ex);
            activity?.SetStatus(Status.Error.WithDescription(ex.Message));
            throw;
        }
    }
    await app.WaitForShutdownAsync();
}
finally
{
    //Ensuring opentelemetry data is flushed before shutting down app
    tracerProvider.ForceFlush();
    tracerProvider.Shutdown();
    await app.DisposeAsync();
}

public partial class Program
{
}
