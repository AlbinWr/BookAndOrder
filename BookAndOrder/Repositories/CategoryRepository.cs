using BookAndOrder.Data;
using BookAndOrder.Interfaces;
using BookAndOrder.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAndOrder.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Category>> GetRandCatAsync(int amount)
        {
            var allCategories = await _context.Categories.ToListAsync();
            return allCategories.OrderBy(x => Guid.NewGuid()).Take(amount);
        }
    }
}
