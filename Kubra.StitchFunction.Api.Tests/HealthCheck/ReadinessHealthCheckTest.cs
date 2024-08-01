using Kubra.StitchFunction.Api.HealthCheck;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Xunit;

namespace Kubra.StitchFunction.Api.Tests.HealthCheck
{

    public class ReadinessHealthCheckTest
    {
        [Theory]
        [InlineData(HealthStatus.Healthy)]
        public async Task ReadinessHealthCheck(HealthStatus expectedHealthStatus)
        {
            var ReadinessHealthCheck = new ReadinessHealthCheck();

            var result = await ReadinessHealthCheck.CheckHealthAsync(new HealthCheckContext());

            Assert.Equal(expectedHealthStatus, result.Status);
        }
    }
}
