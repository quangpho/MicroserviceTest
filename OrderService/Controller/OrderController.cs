using Microsoft.AspNetCore.Mvc;

namespace UserService.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("UserService");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            // Simulate order object
            var order = new { OrderId = id, Product = "Laptop" };

            // Call UserService synchronously over HTTP
            var response = await _httpClient.GetAsync($"/api/user/{id}");
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, "Failed to fetch user");

            var userJson = await response.Content.ReadAsStringAsync();

            return Ok(new
            {
                Order = order,
                User = System.Text.Json.JsonSerializer.Deserialize<object>(userJson)
            });
        }
    }
}
