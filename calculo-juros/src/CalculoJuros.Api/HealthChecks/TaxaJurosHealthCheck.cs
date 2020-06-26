using System.Threading;
using System.Threading.Tasks;
using CalculoJuros.Api.ApiServices.Interfaces;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace CalculoJuros.Api.HealthChecks
{
    public class TaxaJurosHealthCheck : IHealthCheck
    {
        private readonly ITaxaJurosApiService taxaJurosApiService;

        public TaxaJurosHealthCheck(ITaxaJurosApiService taxaJurosApiService)
        {
            this.taxaJurosApiService = taxaJurosApiService;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var health = await taxaJurosApiService.HealthCheck(cancellationToken);

            if (health == "Healthy")
                return HealthCheckResult.Healthy();
            else
                return HealthCheckResult.Unhealthy();
        }
    }
}