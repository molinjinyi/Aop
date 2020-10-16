using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace Ada.SampleA.API.Controllers.V2
{
    //[Authorize]
    [ApiController]
    [Route("SerivceA/{version:apiVersion}/WeatherForecast")]
    [ApiVersion("2.0")]
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

        /// <summary>
        /// 說明 v2
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), 200)]
        [ProducesResponseType(typeof(T), 400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogDebug("Start");
            var rng = new Random();
            _logger.LogDebug("End");
            _logger.LogError("LogError");

            _logger.LogInformation("End............");
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)] + "v2.0"
            })
            .ToArray();
        }


        
    }
    class T
    {
        public Code ErrorCode { get; set; }
        public string Message { get; set; }
    }
    /// <summary>
    /// 狀態碼
    /// </summary>
    enum CodeEnum
    {
        /// <summary>
        /// AAAAA
        /// </summary>

        A = 1,
        /// <summary>
        /// BBBB
        /// </summary>

        B = 2,

        /// <summary>
        /// CCCC
        /// </summary>

        C = 3
    }

    /// <summary>
    /// 錯誤碼
    /// </summary>
    class Code
    {
        /// <summary>
        /// A狀態碼
        /// </summary>
        [SwaggerSchema("The product identifier", ReadOnly = true)]
        public Code A
        {
            get;
        }

        /// <summary>
        /// B狀態碼
        /// </summary>
        public Code B
        {
            get;
        }

        /// <summary>
        /// C狀態碼
        /// </summary>
        public Code C
        {
            get;
        }
    }

}
