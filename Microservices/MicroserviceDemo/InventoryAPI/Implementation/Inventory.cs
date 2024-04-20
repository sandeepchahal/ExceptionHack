
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPI.Implementation;

public class Inventory
{
    [Key]
    public int InventoryId { get; set; }
    [Column(TypeName = "nvarchar(50)")]
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}