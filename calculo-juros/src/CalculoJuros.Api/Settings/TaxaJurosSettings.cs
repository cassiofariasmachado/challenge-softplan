using Microsoft.Extensions.Configuration;

namespace CalculoJuros.Api.Settings
{
    public class TaxaJurosSettings
    {
        public string BaseAddress { get; set; }

        public TaxaJurosSettings(IConfiguration configuration)
        {
            configuration.Bind("TaxaJuros", this);
        }
    }
}