using Microsoft.AspNetCore.Mvc;

namespace UserService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            // In real-world, this would query a database
            var user = new { Id = id, Name = "Alice", Email = "alice@example.com" };
            return Ok(user);
        }
    }
}
