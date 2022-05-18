using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Test_Project.Controllers
{
    /// <summary>
    /// 2
    /// </summary>
    [ApiController]
    [Route("Host")]
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
        public HostInfo Get()
        {
            return new HostInfo()
            {
                HostName = Dns.GetHostName(),
                HostIP = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString(),
                Version = 87
            };
        }

        [HttpGet("CheckHealth")]
        public IActionResult CheckHealth()
        {
            if (new Random().Next(100) > -1)
            {
                return Ok("OK");
            }
            else
            {
                return BadRequest();
            }
        }
    }

    public class HostInfo
    {
        public string HostName { get; set; }

        public string HostIP { get; set; }

        public int Version { get; set; }
    }
}
