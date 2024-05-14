using KasetMore.Data.Models;

namespace KasetMore.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task DeleteProduct(int id);
        Task<Product?> GetProductById(int id);
        Task<List<Product>> GetProducts();
        Task UpdateProduct(Product product);
    }
}