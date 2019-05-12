using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApi.Core;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService) {
            _weatherService = weatherService;
        }

        [HttpGet("forecast")]
        public async Task<ActionResult> Forcast(string city, string zipCode)
        {           
            if (!string.IsNullOrWhiteSpace(city))
                return Ok(await _weatherService.ForcastByNameOfThe(city));

            if (!string.IsNullOrWhiteSpace(zipCode))
                return Ok(await _weatherService.ForcastByZip(zipCode));

            return BadRequest("Parameter city or zip code is required");
        }

        [HttpGet("current")]
        public async Task<ActionResult> Weather(string city, string zipCode)
        {           
            if (!string.IsNullOrWhiteSpace(city))
                return Ok(await _weatherService.WeatherByNameOfThe(city));

            if (!string.IsNullOrWhiteSpace(zipCode))
                return Ok(await _weatherService.WeatherByZipCode(zipCode));

            return BadRequest("Parameter city or zip code is required");
        }
    }
}
