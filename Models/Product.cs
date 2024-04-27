using System.ComponentModel.DataAnnotations;

namespace AsyncStoreApp.Models;
public class Product
{
    [Key]
    public int ProductId { get; set; }
    [Required]
    [StringLength(64)]
    public string ProductName { get; set; }
    [Required]
    public List<User> Users { get; set; }= new();
    public ProductInfo ProductInfo { get; set; }

}

