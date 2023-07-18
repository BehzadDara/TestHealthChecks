using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TestHealthChecks
{
    public class ExampleCheck : IHealthCheck
    {
        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var data = new Dictionary<string, object>();

            var actualValue = FakeData.GetActualCount();
            var expectedValue = FakeData.GetExpectedCount();
            data.Add(nameof(expectedValue), expectedValue);
            data.Add(nameof(actualValue), actualValue);

            HealthStatus status;
            if (expectedValue == actualValue)
            {
                status = HealthStatus.Healthy;
            }
            else if (expectedValue * 0.7 <= actualValue && expectedValue > actualValue)
            {
                status = HealthStatus.Degraded;
            }
            else
            {
                status = HealthStatus.Unhealthy;
            }

            var result = new HealthCheckResult(status, null, null, data);
            return await Task.FromResult(result);
        }

    }
}
