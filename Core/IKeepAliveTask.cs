using System.Threading;

namespace WeatherApi.Core 
{
    public interface IKeepAliveTask
    {
        void Run(CancellationToken ancellationToken);
    }
}