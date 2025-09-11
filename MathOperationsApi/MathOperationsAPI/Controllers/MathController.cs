using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MathOperationsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : ControllerBase
    {
        // GET api/math/add?a=5&b=3
        // Asynchronously adds two numbers from query parameters and returns the result
        [HttpGet("add")]
        public async Task<IActionResult> AddAsync([FromQuery] int a, [FromQuery] int b)
        {
            int result = await Task.Run(() => a + b);
            return Ok(new { Operation = "Addition", Result = result });
        }

        // GET api/math/multiply?a=5&b=3
        // Asynchronously multiplies two numbers from query parameters and returns the result
        [HttpGet("multiply")]
        public async Task<IActionResult> MultiplyAsync([FromQuery] int a, [FromQuery] int b)
        {
            int result = await Task.Run(() => a * b);
            return Ok(new { Operation = "Multiplication", Result = result });
        }
    }
}
