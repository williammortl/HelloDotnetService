namespace HelloDotnetService.Controllers
{
    using HelloDotnetService.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// API controller for the Hello endpoint
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HelloController : ControllerBase
    {

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<HelloController> logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        public HelloController(ILogger<HelloController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Get handler
        /// </summary>
        /// <param name="name">name of the person calling</param>
        /// <returns>response</returns>
        [HttpGet]
        public HelloResponse Get([FromQuery] string name = "")
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            
            HelloResponse retVal = null;
            if (name != "")
            {
                retVal = new HelloResponse
                {
                    Message = "Hello World!",
                    Name = name
                };
                this.logger.LogInformation("Hello from: {0} IP: {1}", name, ip);
            }
            else
            {
                HttpContext.Response.StatusCode = 400;
                this.logger.LogError("Hello from IP: {0} didn't include name", ip);
            }

            return retVal;
        }
    }
}
