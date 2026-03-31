using BookAndOrder.Models;
using BookAndOrder.Repositories;

namespace BookAndOrder.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> GetUserOrdersAsync(string orderId);
    }
}
