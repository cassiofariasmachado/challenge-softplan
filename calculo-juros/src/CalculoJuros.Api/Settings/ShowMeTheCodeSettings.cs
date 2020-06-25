using Microsoft.Extensions.Configuration;

namespace CalculoJuros.Api.Settings
{
    public class ShowMeTheCodeSettings
    {
        public string GitHubUrl { get; set; }

        public ShowMeTheCodeSettings(IConfiguration configuration)
        {
            configuration.Bind("ShowMeTheCode", this);
        }
    }
}