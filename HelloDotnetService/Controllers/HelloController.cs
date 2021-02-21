using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloDotnetService.Models;
using System.Net.Http;
using System.ServiceModel;
using System.Web;

namespace HelloDotnetService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {
        private readonly ILogger<HelloController> _logger;

        public HelloController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public HelloResponse Get([FromQuery] string name = "")
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            return new HelloResponse
            {
                Message = String.Format("Hello from: {0} IP: {1}", name, ip),
                Name = name
            };
        }
    }
}
