using Kubra.StitchFunction.Api.HealthCheck;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Xunit;

namespace Kubra.StitchFunction.Api.Tests.HealthCheck
{

    public class LivenessHealthCheckTest
    {
        [Theory]
        [InlineData(HealthStatus.Healthy)]
        public async Task LivenessHealthCheck(HealthStatus expectedHealthStatus)
        {
            var livenessHealthCheck = new LivenessHealthCheck();

            var result = await livenessHealthCheck.CheckHealthAsync(new HealthCheckContext());

            Assert.Equal(expectedHealthStatus, result.Status);
        }
    }
}
