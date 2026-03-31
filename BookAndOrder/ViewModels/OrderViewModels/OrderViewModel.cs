using BookAndOrder.Models;

namespace BookAndOrder.ViewModels.OrderViewModels
{
    public class OrderViewModel
    {
        public decimal TotalPrice { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
