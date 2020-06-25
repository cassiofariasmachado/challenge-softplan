using CalculoJuros.Api.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CalculoJuros.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly ShowMeTheCodeSettings settings;

        public ShowMeTheCodeController(ShowMeTheCodeSettings settings)
        {
            this.settings = settings;
        }

        /// <summary>
        /// Retorna o endereço do GitHub que o projeto esta disponível.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(decimal), StatusCodes.Status200OK)]
        public string Get() => settings.GitHubUrl;
    }
}