namespace HelloDotnetService.Controllers
{
    using HelloDotnetService.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;

    /// <summary>
    /// API controller for the Ping endpoint
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<PingController> logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        public PingController(ILogger<PingController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Get handler
        /// </summary>
        /// <returns>response</returns>
        [HttpGet]
        public PingResponse Get()
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            this.logger.LogInformation("Ping from IP: {0}", ip);
            return new PingResponse
            {
                Message = "Pong!",
                Time = DateTime.Now
            };
        }
    }
}
