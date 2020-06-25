using System.Threading;
using System.Threading.Tasks;

namespace CalculoJuros.Api.Services.Interfaces
{
    public interface ICalculaJurosService
    {
        Task<decimal> CalcularJurosComposto(decimal valorInicial, int meses, CancellationToken cancellationToken);
    }
}