using System.Threading;
using CalculoJuros.Api.ApiServices.Interfaces;
using CalculoJuros.Api.Services;
using FakeItEasy;
using Xunit;

namespace CalculoJuros.Api.Test.Services
{
    public class CalculaJurosServiceTest
    {
        [Theory]
        [InlineData(0.01, 100, 5, 105.10)]
        [InlineData(0.2, 150, 10, 928.76)]
        [InlineData(0.1, 1000, 9, 2357.94)]
        public async void DeveCalcularJurosCompostosCorretamente(
            decimal taxaJuros,
            decimal valorInicial,
            int meses,
            decimal jurosEsperado
        )
        {
            var taxaJurosApiService = A.Fake<ITaxaJurosApiService>();

            A.CallTo(() => taxaJurosApiService.ObterTaxaJuros(A<CancellationToken>.Ignored))
                .Returns(taxaJuros);

            var service = new CalculaJurosService(taxaJurosApiService);

            var jurosComposto = await service.CalcularJurosComposto(valorInicial, meses, default(CancellationToken));

            Assert.Equal(jurosEsperado, jurosComposto);
        }
    }
}