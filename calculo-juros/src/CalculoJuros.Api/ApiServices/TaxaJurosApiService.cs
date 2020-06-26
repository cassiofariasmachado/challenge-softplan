using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CalculoJuros.Api.ApiServices.Interfaces;
using CalculoJuros.Api.Settings;

namespace CalculoJuros.Api.ApiServices
{
    public class TaxaJurosApiService : ITaxaJurosApiService
    {
        private readonly HttpClient httpClient;

        public TaxaJurosApiService(HttpClient httpClient, TaxaJurosSettings settings)
        {
            httpClient.BaseAddress = new Uri(settings.BaseAddress);
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            this.httpClient = httpClient;
        }

        public async Task<decimal> ObterTaxaJuros(CancellationToken cancellationToken)
        {
            var response = await httpClient.GetAsync("taxaJuros", cancellationToken);
            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<decimal>(json);
        }

        public async Task<string> HealthCheck(CancellationToken cancellationToken)
        {
            var response = (await httpClient.GetAsync("health", cancellationToken))
               .EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}