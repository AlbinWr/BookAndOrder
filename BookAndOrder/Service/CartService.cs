using BookAndOrder.Interfaces;
using BookAndOrder.Models;

namespace BookAndOrder.Service
{
    public class CartService : ICartService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepo;
        private const string CartSessionKey = "Cart";

        public CartService(IHttpContextAccessor httpContextAccessor, IProductRepository productRepo)
        {
            _httpContextAccessor = httpContextAccessor;
            _productRepo = productRepo;
        }

        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public List<CartItem> GetCart()
        {
            return Session.GetObject<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();
        }

        public async Task AddToCartAsync(int productId, int quantity)
        {
            var cart = GetCart();
            var itemInCart = cart.FirstOrDefault(i => i.ProductId == productId);
            int currentStock = await _productRepo.GetStockAsync(productId);

            if (currentStock >= (itemInCart?.Quantity ?? 0) + quantity)
            {
                if (itemInCart != null)
                {
                    itemInCart.Quantity += quantity;
                }
                else
                {
                    var product = await _productRepo.GetByIdAsync(productId);
                    if (product != null)
                    {
                        cart.Add(new CartItem
                        {
                            ProductId = product.ProductId,
                            ProductName = product.Name,
                            Price = product.Price,
                            Quantity = quantity,
                            ImageUrl = product.ImageUrl
                        });
                    }
                }
                Session.SetObject(CartSessionKey, cart);
            }
            else
            {
                throw new InvalidOperationException("Not enough items in stock.");
            }
        }

        public void RemoveFromCart(int productId)
        {
            var cart = GetCart();
            var itemInCart = cart.FirstOrDefault(i => i.ProductId == productId);
            if (itemInCart != null)
            {
                cart.Remove(itemInCart);
                Session.SetObject(CartSessionKey, cart);
            }
        }

        public void ClearCart()
        {
            Session.Remove(CartSessionKey);
        }

        public void DecreaseQuantity(int productId)
        {
            var cart = GetCart();
            var itemInCart = cart.FirstOrDefault(i => i.ProductId == productId);

            if (itemInCart != null)
            {
                if (itemInCart.Quantity > 1)
                {
                    itemInCart.Quantity -= 1;
                }
                else
                {
                    cart.Remove(itemInCart);
                }
                Session.SetObject(CartSessionKey, cart);
            }
        }
        public async Task IncreaseQuantityAsync(int productId)
        {
            var cart = GetCart();
            var itemInCart = cart.FirstOrDefault(i => i.ProductId == productId);
            int currentStock = await _productRepo.GetStockAsync(productId);


            if (itemInCart != null && currentStock > itemInCart.Quantity)
            {
                itemInCart.Quantity += 1;
                Session.SetObject(CartSessionKey, cart);
            }
        }
        public int GetCartCount()
        {
            return GetCart().Sum(i => i.Quantity);
        }
    }
}
