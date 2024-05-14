using KasetMore.Data.Models;
using KasetMore.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KasetMore.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly KasetMoreContext _context;

        public ProductRepository(KasetMoreContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products
                .Include(p => p.ProductImages)
                .ToListAsync();
        }
        public async Task<Product?> GetProductById(int id)
        {
            return await _context.Products
                .Where(p => p.ProductId == id)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync();
        }
        public async Task AddProduct(Product product)
        {
            try
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteProduct(int id)
        {
            try
            {
                await _context.Products
                    .Where(p => p.ProductId == id)
                    .ExecuteDeleteAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
