
using AsyncStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncStoreApp;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductInfo> ProductInfos { get; set; }

}