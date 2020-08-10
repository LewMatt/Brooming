using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brooming_pl.DBClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Brooming_pl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        

        /*
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            using(var session = NH.OpenSession())
            {
                yield return session.Query<Users>().Where(x => x.UserId == 1).FirstOrDefault<Users>();
            }
        }
        */

    }
}
