using Microsoft.AspNetCore.Mvc;

namespace MathWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        // GET: api/Math/Add?num1=5&num2=3
        [HttpGet("Add")]
        public IActionResult Add(double num1, double num2)
        {
            double result = num1 + num2;
            return Ok(new { Number1 = num1, Number2 = num2, Operation = "Add", Result = result });
        }

        // GET: api/Math/Multiply?num1=5&num2=3
        [HttpGet("Multiply")]
        public IActionResult Multiply(double num1, double num2)
        {
            double result = num1 * num2;
            return Ok(new { Number1 = num1, Number2 = num2, Operation = "Multiply", Result = result });
        }
    }
}
