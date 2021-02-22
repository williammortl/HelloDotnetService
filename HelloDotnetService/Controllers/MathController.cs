namespace HelloDotnetService.Controllers
{
    using HelloDotnetService.Enums;
    using HelloDotnetService.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;

    /// <summary>
    /// API controller for the Math endpoint
    /// </summary>
    [ApiController]
    [Route("Math/{op?}")]
    public class MathController : ControllerBase
    {

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<HelloController> logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">logger</param>
        public MathController(ILogger<HelloController> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        /// Post handler
        /// </summary>
        /// <param name="op">what math operator to use Add | Subtract | Multiply</param>
        /// <param name="numbers">numbers to operate on</param>
        /// <returns>response</returns>
        [HttpPost]
        public MathNumbers Post(string op = "", [FromBody] MathNumbers numbers = null)
        {
            var ip = HttpContext.Connection.RemoteIpAddress.ToString();

            // parse operator
            MathOperators mathOp;
            if (!Enum.TryParse(op, true, out mathOp))
            {
                mathOp = MathOperators.ImproperOp;
            }

            // switch math function
            Func<double, double, double> mathFunction = null;
            switch (mathOp)
            {
                case MathOperators.Add:
                    {
                        mathFunction = (total, newNumber) =>
                        {
                            return total + newNumber;
                        };
                        break;
                    }
                case MathOperators.Subtract:
                    {
                        mathFunction = (total, newNumber) =>
                        {
                            return total - newNumber;
                        };
                        break;
                    }
                case MathOperators.Multiply:
                    {
                        mathFunction = (total, newNumber) =>
                        {
                            return total * newNumber;
                        };
                        break;
                    }
            }

            var retVal = new MathNumbers();
            if (numbers == null)
            {
                HttpContext.Response.StatusCode = 400;
                this.logger.LogError("Body was missing JSON (or was malformed) IP: {0}", ip);
            }
            else if (mathFunction == null)
            {
                HttpContext.Response.StatusCode = 400;
                this.logger.LogError("Improper operator: {0} IP: {1}", op, ip);
            }
            else
            {

                // do the math
                retVal.Numbers = new double[1]
                {
                    numbers.Numbers.Skip(1).Aggregate<double, double>(numbers.Numbers.First(),
                       (total, n) => mathFunction(total, n))
                };
                this.logger.LogInformation("Performed operation: {0} IP: {1}", op, ip);
            }

            return retVal;
        }
    }
}
