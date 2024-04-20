using Microsoft.EntityFrameworkCore;

namespace InventoryAPI.Implementation;

public class InventoryDbContext:DbContext
{
    public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options)
    {
    }
    public DbSet<Inventory> Inventories { get; set; } = null!;    
}