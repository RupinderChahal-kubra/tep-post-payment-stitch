using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Kubra.StitchFunction.Api.HealthCheck
{
    /// <summary>
    /// Readiness probe health Check
    /// </summary>
    public class ReadinessHealthCheck : IHealthCheck
    {
        /// <summary>
        /// Check Readiness specific health check
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new HealthCheckResult(HealthStatus.Healthy,
                "App is ready", null));
        }
    }
}
