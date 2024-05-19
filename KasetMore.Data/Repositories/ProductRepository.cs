using KasetMore.ApplicationCore.Models;
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
        public async Task<List<Product>> GetProductByEmail(string email)
        {
            return await _context.Products
                .Where(p => p.UserEmail == email)
                .Include(p => p.ProductImages)
                .ToListAsync();
        }
        public async Task AddProduct(ProductModel product)
        {
            try
            {
                var base64Images = new List<ProductImage>();
                foreach (var image in product.ProductImages)
                {
                    using var stream = new MemoryStream();
                    await image.CopyToAsync(stream);
                    base64Images.Add(new ProductImage
                    {
                        Image = Convert.ToBase64String(stream.ToArray())
                    });
                }
                var productToAdd = new Product
                {
                    ProductName = product.ProductName,
                    Province = product.Province,
                    Rating = product.Rating,
                    Amount = product.Amount,
                    UserEmail = product.UserEmail,
                    Price = product.Price,
                    ProductImages = base64Images,
                    CreateDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };
                await _context.Products.AddAsync(productToAdd);
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
