using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApi.Models;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://openweathermap.org/data/2.5/weather?q=London,uk&appid=b6907d289e10d714a6e88b30761fae22");
            var response = await client.SendAsync(request);
            var apiWeatherDataString = await response.Content.ReadAsStringAsync();
            
            dynamic dynamicApiData = JsonConvert.DeserializeObject<dynamic>(apiWeatherDataString);
            
            return Ok(Weather.SupplyFrom(dynamicApiData));
        }

    }
}
