using Kubra.Common.Stitch.Models;
using Kubra.Common.WebApi.Extensions;
using Kubra.StitchFunction.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;

namespace Kubra.Pact.Tests.StitchPacts
{
    public class StitchTestStartup
    {
        /// <summary>
        /// </summary>
        /// <param name="configuration"></param>
        public StitchTestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// Runtime calls ConfigureServices before Configure
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var mockedBalanceService = new Mock<IBalanceService>();

            mockedBalanceService.Setup(x => x.GetBalance(It.IsAny<string>())).ReturnsAsync(new StitchBalanceResponse
            {
                CurrentAmountDue = 64.74m,
                AmountDueAfterDueDate = 112.0m,
                BalanceForward = 12.34m,
                BilledAmount= 45.84m,
                CurrentCharges = 89.24m,
                DueDate = DateTime.Parse("2023-08-23T22:02:10Z").ToUniversalTime(),
                LastUpdatedAtSourceDate = DateTime.Parse("2023-08-23T22:02:10Z").ToUniversalTime(),
                MinimumAmountDue = 64.74m
            });

            var mockedPaymentService = new Mock<IPostPaymentService>();

            mockedPaymentService.Setup(x => x.PostPayment(It.IsAny<MessageValue>())).ReturnsAsync(true);

            services.AddControllers(options => options.AddKubraResponseCacheProfiles().EnableEndpointRouting = false)
                .AddApplicationPart(typeof(Program).Assembly);
            services.AddSingleton(mockedBalanceService.Object);
            services.AddSingleton(mockedPaymentService.Object);
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressInferBindingSourcesForParameters = true;
            });
        }

        /// <summary>This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// Runtime calls Configure after ConfigureServices</summary>
        /// <param name="app"></param>
        /// <param name="hostEnvironment"></param>
        public void Configure(IApplicationBuilder app, IHostEnvironment hostEnvironment)
        {
            app.UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
            app.UseCors(corsBuilder => corsBuilder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());
        }
    }
}
