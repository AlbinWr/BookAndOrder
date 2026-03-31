using BookAndOrder.Models;

namespace BookAndOrder.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetRandCatAsync(int amount);
    }
}
