namespace HelloDotnetService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using HelloDotnetService.Models;

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
