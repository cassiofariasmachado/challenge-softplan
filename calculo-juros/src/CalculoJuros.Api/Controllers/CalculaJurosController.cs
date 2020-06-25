using System.Threading;
using System.Threading.Tasks;
using CalculoJuros.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculoJuros.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService calculaJurosService;

        public CalculaJurosController(ICalculaJurosService calculaJurosService)
        {
            this.calculaJurosService = calculaJurosService;
        }

        /// <summary>
        /// Calcula o juros composto baseado nos parâmetros informados.
        /// </summary>
        [HttpGet]
        public Task<decimal> Get([FromQuery] decimal valorInicial, [FromQuery] int meses, CancellationToken cancellationToken)
            => calculaJurosService.CalcularJurosComposto(valorInicial, meses, cancellationToken);
    }
}
