using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Kubra.StitchFunction.Api.HealthCheck
{
    /// <summary>
    /// Liveness probe health Check
    /// </summary>
    public class LivenessHealthCheck : IHealthCheck
    {
        /// <summary>
        /// Check liveness specific health check
        /// </summary>
        /// <param name="context"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new HealthCheckResult(HealthStatus.Healthy,
                "App is ready for live", null));
        }
    }
}
