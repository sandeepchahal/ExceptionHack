using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

[Route("api/product")]
[ApiController]
public class ProductController(IMemoryCache memoryCache, ILogger<ProductController> logger) : ControllerBase
{
    public static List<Product> products = [
        new Product(){Id=1, Name ="test", Description="test 1"},
        new Product(){Id=2, Name ="test", Description="test 2"},
        new Product(){Id=3, Name ="test", Description="test 3"},
    ];

    [HttpGet("get/{id}")]
    public IActionResult Get(int id)
    {
        if (memoryCache.TryGetValue(id, out Product? product))
        {
            logger.LogInformation($"{id} is being pulled from cache");
            return Ok(product);
        }
        var result = products.Find(col => col.Id == id);
        var cacheOptions = new MemoryCacheEntryOptions()
        .SetAbsoluteExpiration(TimeSpan.FromMinutes(5))
        .SetSlidingExpiration(TimeSpan.FromMinutes(2));
        memoryCache.Set(id, result, cacheOptions);
        logger.LogInformation($"{id} is being saved into cache");

        return Ok(result);
    }
}


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}