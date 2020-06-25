using System.Threading;
using CalculoJuros.Api.Controllers;
using CalculoJuros.Api.Services.Interfaces;
using FakeItEasy;
using Xunit;

namespace CalculoJuros.Api.Test.Controllers
{
    public class CalculaJurosControllerTest
    {
        [Fact]
        public async void DeveCalcularJurosCompostoCorretamente()
        {
            var calculaJurosService = A.Fake<ICalculaJurosService>();

            A.CallTo(() => calculaJurosService.CalcularJurosComposto(
                    A<decimal>.Ignored,
                    A<int>.Ignored,
                    A<CancellationToken>.Ignored)
            ).Returns(105.10M);

            var controller = new CalculaJurosController(calculaJurosService);

            Assert.Equal(105.10M, await controller.Get(100, 5, default(CancellationToken)));
        }
    }
}
