namespace OrderAPI.Models;

public class Order
{
    public int OrderId { get; set; }
    public Product Product { get; set; } 
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}