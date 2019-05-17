using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherApi.Core {
    public interface IRouter
    {
        Task<string> SendRequest(HttpMethod method, string parameters);
        Task<string> SendKeepAliveRequest();
    }
}