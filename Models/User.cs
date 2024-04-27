using System.ComponentModel.DataAnnotations;

namespace AsyncStoreApp.Models;
public enum Role
{
    Customer,
    Seller
}
public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(64)]
    public string Name { get; set; }

    [Required]
    public Role Role { get; set; }

    public List<Product> Products { get; set; } = new();

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Role: {Role}, Products: {Products.Count}";
    }
}

