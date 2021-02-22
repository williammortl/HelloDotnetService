namespace HelloDotnetService.Controllers
{
    using HelloDotnetService.Db;
    using HelloDotnetService.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    /// <summary>
    /// API controller for the Db endpoint
    /// </summary>
    [ApiController]
    [Route("Db/{id?}")]
    public class DbController : ControllerBase
    {

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<DbController> logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        public DbController(ILogger<DbController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Retrieves a person
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>person or null</returns>
        [HttpGet]
        public Person Get(int id = -999)
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();
            
            var person = Database.GetPersonByID(id);
            if (person == null)
            {
                HttpContext.Response.StatusCode = 400;
                this.logger.LogError("Db id: {0} was not found IP: {1}", id, ip);
            }
            else
            {
                this.logger.LogInformation("Db id: {0} was retrieved IP: {1}", id, ip);
            }

            return person;
        }

        /// <summary>
        /// Adds/ saves a person to the db
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="person">person record to add</param>
        [HttpPost]
        public void Post(int id = -999, [FromBody] Person person = null)
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            // parse body
            if (person == null)
            {
                HttpContext.Response.StatusCode = 400;
                this.logger.LogError("Body was missing JSON (or was malformed) IP: {0}", ip);
            }
            else
            {

                // add to db
                Database.AddPerson(id, person);
                HttpContext.Response.StatusCode = 200;
            }
        }
    }
}

