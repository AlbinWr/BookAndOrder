using BookAndOrder.Models;

namespace BookAndOrder.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<int> GetStockAsync(int productId);

        //Override parent method to include search functionality
        Task<IEnumerable<Product>> GetAllAsync(string searchString, int? categoryId);

        Task<IEnumerable<Product>> GetFeaturedProductsAsync(int amount);

        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
    }
}
