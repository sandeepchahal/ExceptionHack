using Microsoft.AspNetCore.Mvc;
using OrderAPI.Models;

namespace OrderAPI.Controllers;

[Route("api/order")]
[ApiController]
public class OrderController:ControllerBase
{
    private HttpClient _httpClientProduct;
    private HttpClient _httpClientInventory;

    public OrderController(IHttpClientFactory httpClientFactory)
    {
        _httpClientProduct = httpClientFactory.CreateClient("ProductAPI");
        _httpClientInventory = httpClientFactory.CreateClient("InventoryAPI");
    }
    [HttpPost("create")]
    public async Task<IActionResult> CreateOrder(Order order, CancellationToken token)
    {
        // we have to make the call to product api to check the quantity of product Id
        var productResponse = await _httpClientProduct
            .PostAsync($"api/product/prepare-product/{order.Product.Id}/{order.Product.Quantity}/{token}", 
                new StringContent(string.Empty));
        
        var inventoryResponse = await _httpClientInventory
            .PostAsJsonAsync($"api/product/prepare-inventory/{order.Inventory.InventoryId}/{order.Inventory.Quantity}/{token}", 
                new StringContent(string.Empty));

        if (productResponse.IsSuccessStatusCode && inventoryResponse.IsSuccessStatusCode)
        {
            // start with the commit phase
            var productCommit =
                await _httpClientProduct.PostAsync($"api/product/commit-product", new StringContent(string.Empty));
            

            if (productCommit.IsSuccessStatusCode)
            {
                var inventoryCommit =
                    await _httpClientProduct.PostAsync($"api/inventory/commit-inventory", new StringContent(string.Empty));
                if (inventoryCommit.IsSuccessStatusCode)
                {
                    return StatusCode(StatusCodes.Status200OK, "Order is created");

                }
                else
                {
                    // roll back inventory table changes
                    // roll back cannot happen for product table
                }
                
            }
            else
            {
                var productRollback =
                    await _httpClientProduct.PostAsync($"api/product/rollback-product", new StringContent(string.Empty));

            }
            return StatusCode(StatusCodes.Status501NotImplemented, "Order is not created");

        }
        return StatusCode(StatusCodes.Status501NotImplemented, "product or inventory response is not ok");

    }
    
    
     [HttpPost("saga-create")]
    public async Task<IActionResult> SagaCreateOrder(Order order, CancellationToken token)
    {
        var productResponse = await _httpClientProduct
            .PostAsync($"api/product/saga-prepare-product/{order.Product.Id}/{order.Product.Quantity}/{token}", 
                new StringContent(string.Empty));
        if (!productResponse.IsSuccessStatusCode)
        {
            return StatusCode(StatusCodes.Status501NotImplemented, "Product response is not oK");
        }
        var inventoryResponse = await _httpClientInventory
            .PostAsync($"api/product/prepare-inventory/{order.Inventory.InventoryId}/{order.Inventory.Quantity}/{token}", 
                new StringContent(string.Empty));

        if (inventoryResponse.IsSuccessStatusCode)
        {
            // another api shipping 
            return StatusCode(StatusCodes.Status501NotImplemented, "Order is created");
        }

        if (await CompensateProduct(order.Product.Id, order.Product.Quantity, token: token))
        {
            return StatusCode(StatusCodes.Status501NotImplemented, "Product is compensated because Inventory failed to process");
        }
        return StatusCode(StatusCodes.Status501NotImplemented, "Order is created");
    }

    private async Task<bool> CompensateProduct(int id, int quantity, CancellationToken token)
    {
        var compensateProductResponse = await _httpClientProduct
            .PostAsync($"api/product/saga-compensate-product/{id}/{quantity}/{token}", 
                new StringContent(string.Empty));
        if (compensateProductResponse.IsSuccessStatusCode)
        {
            return true;
        }

        return false;
    }
}