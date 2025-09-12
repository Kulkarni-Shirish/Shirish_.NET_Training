using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserPortalAuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProtectedController : ControllerBase
    {
        // This endpoint requires a valid JWT token
        [HttpGet]
        [Authorize]
        public IActionResult GetSecretData()
        {
            // You can also read the username from claims
            var username = User.Identity?.Name ?? "Unknown";
            return Ok(new
            {
                Message = $"Hello {username}, this is protected data from the API!"
            });
        }
    }
}
