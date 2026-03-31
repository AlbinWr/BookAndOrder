using BookAndOrder.Data;
using BookAndOrder.Interfaces;
using BookAndOrder.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAndOrder.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task<int> GetStockAsync(int productId)
        {
             return await _context.Products
                .Where(p => p.ProductId == productId)
                .Select(p => p.Stock)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync(string searchString, int? categoryId)
        {
            var linqQuery = _context.Products
                .Include(p => p.Category)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                string search = searchString.ToLower();
                linqQuery = linqQuery.Where(p => 
                    p.Name.ToLower().Contains(search) || 
                    p.Description.ToLower().Contains(search));
            }
            if (categoryId.HasValue)
            {
                linqQuery = linqQuery.Where(p => 
                    p.CategoryId == categoryId.Value);
            }
            return await linqQuery.ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetFeaturedProductsAsync(int amount)
        {
            return await _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.ProductId)
                .Take(amount)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId)
        {
            return await _context.Products
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.Category)
                .ToListAsync();
        }
    }
}
