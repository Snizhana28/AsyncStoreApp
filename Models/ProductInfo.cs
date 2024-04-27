using System.ComponentModel.DataAnnotations;

namespace AsyncStoreApp.Models;

public class ProductInfo
{
    [Key]
    public int ProductInfoId { get; set; }
    [Required]
    public int ProductId { get; set; }
    [Required]
    public Product Product { get; set; }
    [Required]
    [StringLength(256)]
    public string Description { get; set; }
    [Required]
    public double Price { get; set; }
}

