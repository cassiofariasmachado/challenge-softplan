using TaxaJuros.Api.Controllers;
using Xunit;

namespace TaxaJuros.Api.Test.Controllers
{
    public class TaxaJurosControllerTest
    {
        [Fact]
        public void DeveRetornarATaxaDeJurosCorreta()
        {
            var controller = new TaxaJurosController();

            var taxa = controller.Get();

            Assert.Equal(0.01M, taxa);
        }
    }
}
