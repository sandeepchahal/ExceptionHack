using System.Data;
using InventoryAPI.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace InventoryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    private readonly InventoryDbContext _inventoryDbContext;
    private IDbContextTransaction _transaction;
    public InventoryController(InventoryDbContext inventoryDbContext)
    {
        _inventoryDbContext = inventoryDbContext;
    }

    [HttpPost("reserve-inventory/{id:int}/{quantity:int}/{token}")]
    public async Task<IActionResult> ReserveInventory(int id, int quantity, CancellationToken token)
    {
        try
        {
            var isolationLevel = IsolationLevel.Serializable;
            _transaction = await _inventoryDbContext.Database.BeginTransactionAsync(token);
                var inventory = await _inventoryDbContext.Inventories.FindAsync(new object?[] { id }, cancellationToken: token);
                if (inventory is null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                inventory.Quantity -= quantity;
                await _inventoryDbContext.SaveChangesAsync(token);
               
            return StatusCode(StatusCodes.Status200OK);

        }
        catch
        {
            return StatusCode(StatusCodes.Status200OK);
        }

    }
    
    
    [HttpPost("commit-inventory/{token}")]
    public async Task<IActionResult> RollbackInventory(CancellationToken token)
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
    
}