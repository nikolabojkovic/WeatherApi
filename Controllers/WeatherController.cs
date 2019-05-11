﻿using System;
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
        public async Task<ActionResult> Forcast(string city, string code)
        {           
            if (!string.IsNullOrWhiteSpace(city))
                return Ok(await _weatherService.ForcastByNameOfThe(city));

            if (!string.IsNullOrWhiteSpace(code))
                return Ok(await _weatherService.ForcastByZip(code));

            return BadRequest("Parameter city or zip code is required");
        }
    }
}
