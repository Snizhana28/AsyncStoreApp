using AsyncStoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AsyncStoreApp;

public class ProductRepository : IRepository<Product>
{
    private readonly DataContext _context;

    public ProductRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Product item)
    {
        _context.Products.Add(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IQueryable<Product>> GetAllAsync(CancellationToken token)
    {
        return (IQueryable<Product>)await _context.Products.Include(p => p.ProductInfo)
        .AsQueryable()
        .ToListAsync(token);

    }

    public async Task<Product> GetByIdAsync(int id)
    {
        Product product = await _context.Products.Include(p => p.ProductInfo)
                        .FirstOrDefaultAsync(p => p.ProductId == id);
        if (product == null)
            throw new ArgumentException("Product not found");

        return product;
    }
}


