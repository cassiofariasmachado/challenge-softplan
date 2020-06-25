using System;
using System.Threading;
using System.Threading.Tasks;
using CalculoJuros.Api.ApiServices.Interfaces;
using CalculoJuros.Api.Services.Interfaces;

namespace CalculoJuros.Api.Services
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private readonly ITaxaJurosApiService taxaJurosApiService;

        public CalculaJurosService(ITaxaJurosApiService taxaJurosApiService)
        {
            this.taxaJurosApiService = taxaJurosApiService;
        }

        public async Task<decimal> CalcularJurosComposto(decimal valorInicial, int meses, CancellationToken cancellationToken)
        {
            decimal taxaJuros = await taxaJurosApiService.ObterTaxaJuros(cancellationToken);
            double juros = Math.Pow((double)(1M + taxaJuros), meses);

            decimal jurosComposto = valorInicial * (decimal)juros;

            return Truncate(jurosComposto, 2);
        }

        private decimal Truncate(decimal valor, int casasDecimais)
        {
            int fator = (int)Math.Pow(10, casasDecimais);
            return Math.Truncate(valor * fator) / fator;
        }
    }
}