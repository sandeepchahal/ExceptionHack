using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;

namespace OrderAPI.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController:ControllerBase
{
    [HttpPost("create")]
    public IActionResult CreateOrder(Order order)
    {
        // we have to make the call to product api to check the quantity of product Id
        
        return StatusCode(StatusCodes.Status200OK, "Order creation is called");
    }
}