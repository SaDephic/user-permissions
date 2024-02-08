using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace user_permissions.Models
{
    public class StartupBackgroundService : BackgroundService
    {
        private readonly StartupHealthCheck _healthCheck;

        public StartupBackgroundService(StartupHealthCheck healthCheck)
            => _healthCheck = healthCheck;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Simulate the effect of a long-running task.
            await Task.Delay(TimeSpan.FromSeconds(15), stoppingToken);

            _healthCheck.StartupCompleted = true;
        }
    }
    public class StartupHealthCheck : IHealthCheck
    {
        private volatile bool _isReady;

        public bool StartupCompleted
        {
            get => _isReady;
            set => _isReady = value;
        }

        public Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            if (StartupCompleted)
            {
                return Task.FromResult(HealthCheckResult.Healthy("The startup task has completed."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("That startup task is still running."));
        }
    }
}
