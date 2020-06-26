using System.Threading;
using System.Threading.Tasks;

namespace CalculoJuros.Api.ApiServices.Interfaces
{
    public interface ITaxaJurosApiService
    {
        Task<decimal> ObterTaxaJuros(CancellationToken cancellationToken);
        Task<string> HealthCheck(CancellationToken cancellationToken);
    }
}