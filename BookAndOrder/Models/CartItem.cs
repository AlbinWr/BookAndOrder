using System.ComponentModel.DataAnnotations;

namespace BookAndOrder.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(1, 50, ErrorMessage = "You can buy at least 1 and at most 50 of the same item. Contact support for bulk orders.")]
        public int Quantity { get; set; }
        public string? ImageUrl { get; set; }
    }
}
