using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Implementation;

public class ProductDbContext:DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; } = null!;    
}