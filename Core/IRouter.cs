using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WeatherApi.Core {
    public interface IRouter
    {
        Task<string> SendRequest(HttpMethod method, string parameters, CancellationToken cancellationToken);
        Task<string> SendKeepAliveRequest(CancellationToken cancellationToken);
    }
}