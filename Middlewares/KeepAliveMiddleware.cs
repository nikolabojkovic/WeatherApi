using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WeatherApi.MIddleweres 
{
    public class KeepAliveMiddleware 
    {
        private readonly RequestDelegate _next;

        public KeepAliveMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path.ToString().Equals("/keepAlive"))
                return;

            await _next.Invoke(httpContext);
        }
    }
}