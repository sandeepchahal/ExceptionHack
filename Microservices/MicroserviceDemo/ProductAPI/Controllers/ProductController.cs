using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using ProductAPI.Implementation;
using ProductAPI.Models;

namespace ProductAPI.Controllers;

[Route("api/product")]
[ApiController]
public class ProductController:ControllerBase
{
    private List<Product> list;
    private readonly ProductDbContext _productDbContext;
    private IDbContextTransaction _transaction;

    public ProductController(ProductDbContext productDbContext)
    {
        _productDbContext = productDbContext;
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
            return StatusCode(StatusCodes.Status500InternalServerError, list);
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
    
    [HttpPost("prepare-product/{id:int}/{quantity:int}/{token}")]
    public async Task<IActionResult> ReserveProduct(int id, int quantity, CancellationToken token)
    {
        try
        {
            _transaction = await _productDbContext .Database.BeginTransactionAsync(token);
            var inventory = await _productDbContext.Products.FindAsync(new object?[] { id }, cancellationToken: token);
            if (inventory is null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            inventory.Quantity -= quantity;
            await _productDbContext.SaveChangesAsync(token);
               
            return StatusCode(StatusCodes.Status200OK);

        }
        catch
        {
            return StatusCode(StatusCodes.Status200OK);
        }

    }

    [HttpPost("commit-product/{token}")]
    public async Task<IActionResult> CommitInventory(CancellationToken token)
    {
        try
        {
            await _transaction.CommitAsync(token);
            return StatusCode(StatusCodes.Status200OK);

        }
        catch
        {
            await _transaction.RollbackAsync(token);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
    
    [HttpPost("rollback-product/{token}")]
    public async Task<IActionResult> RollbackInventory(CancellationToken token)
    {
        try
        {
            await _transaction.RollbackAsync(token);
            return StatusCode(StatusCodes.Status200OK);

        }
        catch
        {
            await _transaction.RollbackAsync(token);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}


