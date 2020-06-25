using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaxaJuros.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class TaxaJurosController : ControllerBase
    {

        /// <summary>
        /// Retorna a taxa de juros.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        public decimal Get() => 0.01M;
    }
}
