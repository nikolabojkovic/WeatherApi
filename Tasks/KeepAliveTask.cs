
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WeatherApi.Core;

namespace WeatherApi.Tasks 
{
    public class KeepAliveTask : IKeepAliveTask
    {
        private readonly IRouter _router;
        private readonly IConfiguration _configuration;

        public KeepAliveTask(IRouter router, IConfiguration configuration) 
        {
            _router = router;
            _configuration = configuration;
        }

        public void Run() {
            var counter = 1;
            Task.Run(async () => {
                await Task.Delay(TimeSpan.FromSeconds(5));   
                while(true) {
                    try
                    {
                        await _router.SendKeepAliveRequest();
                    }
                    catch(Exception ex) {
                        Console.WriteLine($"Ex: {ex.Message}");
                    }

                    Console.WriteLine($"Keep Aliave: {counter++}");  
                    await Task.Delay(TimeSpan.FromMinutes(Convert.ToInt32(_configuration.GetSection("KeepAlive")["delayInMinutes"])));   
                }                    
            });
        }
    }
}