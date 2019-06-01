
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WeatherApi.Core;

namespace WeatherApi.Tasks 
{
    // Keep alive task can be used to keep web app alive if it is not possible
    // to set up application pool to be active all the time in IIS.
    // Default application pool iddle time is 20 min (if web applicataion
    // does not recieve request in 20 min, app will shut down)
    public class KeepAliveTask : IKeepAliveTask
    {
        private readonly IRouter _router;
        private readonly IConfiguration _configuration;
        private readonly ILogger<KeepAliveTask> _logger;

        public KeepAliveTask(IRouter router, IConfiguration configuration, ILogger<KeepAliveTask> logger) 
        {
            _router = router;
            _configuration = configuration;
            _logger = logger;
        }

        public void Run(CancellationToken cancellationToken) {
            var counter = 1;
            Task.Run(async () => {
                // wait for web application to initialize properly
                await Task.Delay(TimeSpan.FromMinutes(2)); 

                while(true) {
                    try
                    {
                        await _router.SendKeepAliveRequest(cancellationToken);
                    }
                    catch(Exception ex) {
                        _logger.LogError(ex, ex.Message);
                    }

                    _logger.LogInformation($"Keep Aliave request #{counter++} sent");  
                    await Task.Delay(TimeSpan.FromMinutes(Convert.ToInt32(_configuration.GetSection("KeepAlive")["delayInMinutes"])));   
                }                    
            }, cancellationToken);
        }
    }
}