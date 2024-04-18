using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;

namespace OrderAPI.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController:ControllerBase
{
    private HttpClient _httpClient;
    public OrderController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ProductAPI");
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        // we have to make the call to product api to check the quantity of product Id
        var response = await _httpClient.GetAsync("api/product/get-all");
        
        return StatusCode(StatusCodes.Status200OK, "Order creation is called");
    }
}