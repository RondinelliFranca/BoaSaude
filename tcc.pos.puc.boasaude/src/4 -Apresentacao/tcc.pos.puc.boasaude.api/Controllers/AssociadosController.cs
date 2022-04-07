﻿using Microsoft.AspNetCore.Mvc;

namespace tcc.pos.puc.boasaude.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssociadosController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
         {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        [HttpGet(Name = "AssociadosController")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}