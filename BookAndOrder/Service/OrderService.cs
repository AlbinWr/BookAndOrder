using BookAndOrder.Interfaces;
using BookAndOrder.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BookAndOrder.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly ICartService _cartService;
        private readonly IProductRepository _productRepo;

        public OrderService(IOrderRepository orderRepo, ICartService cartService, IProductRepository productRepo)
        {
            _orderRepo = orderRepo;
            _cartService = cartService;
            _productRepo = productRepo;
        }

        public async Task<int> PlaceOrderAsync(string? userId = null)
        {
            var cartItems = _cartService.GetCart();
            if (!cartItems.Any())
            {
                return 0;
            }

            foreach(var item in cartItems)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                {
                    throw new Exception($"Sorry, {product?.Name} is out of stock.");
                }
                product.Stock -= item.Quantity;
                await _productRepo.UpdateAsync(product);
            }

            var order = new Order
            {
                OrderDate = DateTime.Now,
                UserId = userId,
                TotalAmount = cartItems.Sum(i => i.Price * i.Quantity),
                OrderItems = cartItems.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };
            await _orderRepo.AddAsync(order);
            _cartService.ClearCart();

            return order.OrderId;
        }
    }
}
