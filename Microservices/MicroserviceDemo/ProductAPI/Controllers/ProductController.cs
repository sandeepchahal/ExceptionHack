using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;

namespace ProductAPI.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController:ControllerBase
{
    private List<Product> list;
    public ProductController()
    {
        list = new List<Product>()
        {
            new Product()
            {
                ProductId = 1,
                Name = "Product-1",
                Description = "This is product 1",
                Price = 1000,
                Quantity = 100
            },
            new Product()
            {
                ProductId = 2,
                Name = "Product-2",
                Description = "This is product 2",
                Price = 2000,
                Quantity = 200
            }, new Product()
            {
                ProductId = 3,
                Name = "Product-3",
                Description = "This is product 3",
                Price = 3000,
                Quantity = 300
            },
        };
    }
    
    [HttpGet("get-all")]
    public IActionResult Get()
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, list);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpGet("get/{id:int}")]
    public IActionResult Get(int id)
    {
        try
        {
            return StatusCode(StatusCodes.Status200OK, list.Where(col=>col.ProductId == id));
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}


