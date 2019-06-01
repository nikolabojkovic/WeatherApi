using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WeatherApi.Core;
using WeatherApi.CityForecast.Queries;
using WeatherApi.ZipCodeForecast.Queries;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("forecast")]
        public async Task<ActionResult> Forcast(string city, string zipCode)
        {           
            if (!string.IsNullOrWhiteSpace(city))
                return Ok(await _mediator.Send(new CityForecastQuery { CityName = city}));

            if (!string.IsNullOrWhiteSpace(zipCode))
                return Ok(await _mediator.Send(new ZipCodeForecastQuery { ZipCode = zipCode}));

            return BadRequest("Parameter city or zip code is missing");
        }

        [HttpGet("current")]
        public async Task<ActionResult> Weather(string city, string zipCode)
        {           
            if (!string.IsNullOrWhiteSpace(city))
                return Ok(await _mediator.Send(new CityCurrentWeatherQuery { CityName = city}));

            if (!string.IsNullOrWhiteSpace(zipCode))
                return Ok(await _mediator.Send(new ZipCodeCurrentWeatherQuery { ZipCode = zipCode}));

            return BadRequest("Parameter city or zip code is missing");
        }
    }
}
