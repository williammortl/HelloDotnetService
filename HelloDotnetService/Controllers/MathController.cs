namespace HelloDotnetService.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Linq;
    using HelloDotnetService.Models;
    using HelloDotnetService.Enums;

    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {

        private readonly ILogger<HelloController> _logger;

        public MathController(ILogger<HelloController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public MathNumbers Post([FromQuery] String op = "", [FromBody] MathNumbers numbers = null)
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

            // do the math
            var retVal = new MathNumbers();
            if (mathFunction == null)
            {
                HttpContext.Response.StatusCode = 400;
            }
            else
            {
                retVal.Numbers = new double[1]
                {
                    numbers.Numbers.Skip(1).Aggregate<double, double>(numbers.Numbers.First(),
                       (total, n) => mathFunction(total, n))
                };
            }

            return retVal;
        }
    }
}
