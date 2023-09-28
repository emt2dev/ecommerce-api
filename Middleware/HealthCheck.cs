using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace api.Middleware
{
    public class HealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken CT = default)
        {
            bool isAPIHealthy = true;

            /* Custom Logic and Checks here */

            if (isAPIHealthy) return Task.FromResult(HealthCheckResult.Healthy(GLOSSARY.GreenHealth));

            return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, GLOSSARY.YellowHealth));
        }
    }
}
