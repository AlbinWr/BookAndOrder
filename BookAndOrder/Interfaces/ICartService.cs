using BookAndOrder.Models;

namespace BookAndOrder.Interfaces
{
    public interface ICartService
    {
        List<CartItem> GetCart();
        Task AddToCartAsync(int productId, int quantity);
        void RemoveFromCart(int productId);
        void ClearCart();
        void DecreaseQuantity(int productId);
        Task IncreaseQuantityAsync(int productId);
        int GetCartCount();
    }
}
