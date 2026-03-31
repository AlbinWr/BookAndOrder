using BookAndOrder.Data;
using BookAndOrder.Interfaces;
using BookAndOrder.Models;
using BookAndOrder.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookAndOrder.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository _productRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;

        public OrderController(ApplicationDbContext context,
            IOrderRepository orderRepo, IProductRepository productRepo, UserManager<ApplicationUser> userManager, IOrderService orderService, ICartService cartService)
        {
            _context = context;
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _userManager = userManager;
            _orderService = orderService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CheckoutAsync()
        {
            var cartItems = _cartService.GetCart();

            if (!cartItems.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty!";
                return RedirectToAction("Index", "Cart");
            }

            var user = await _userManager.GetUserAsync(User);

            var viewModel = new ViewModels.OrderViewModels.CheckoutViewModel
            {
                CartItems = cartItems,
                TotalAmount = cartItems.Sum(i => i.Quantity * i.Price),
                FirstName = user?.FirstName,
                LastName = user?.LastName,
                Address = user?.Address,
                City = user?.City,
                Postcode = user?.Postcode
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder()
        {
            var userId = _userManager.GetUserId(User);

            try
            {
                var orderId = await _orderService.PlaceOrderAsync(userId);
                if (orderId == 0)
                {
                    TempData["ErrorMessage"] = "Your cart is empty.";
                    return RedirectToAction("Index", "Cart");
                }
                TempData["SuccessMessage"] = "Your order has been placed successfully!";
                return RedirectToAction("Confirmation", new { id = orderId });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Cart");
            }
        }

        [Authorize]
        public IActionResult Confirmation(int id)
        {
            ViewBag.OrderId = id;
            return View();
        }

        [Authorize]
        public async Task<IActionResult> ShowUserOrders()
        {
            var userId = _userManager.GetUserId(User);

            var orders = await _orderRepo.GetUserOrdersAsync(userId);

            return View(orders);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkAsPaid(int orderId)
        {
            var order = await _orderRepo.GetByIdAsync(orderId);
            if (order != null)
            {
                order.IsPaid = true;
                order.PaymentDate = DateTime.Now;

                await _orderRepo.UpdateAsync(order);
                TempData["SuccessMessage"] = "Order paid successfully!";
            }
            else {
                TempData["ErrorMessage"] = "Order not found!";
            }
            return RedirectToAction("ShowUserOrders");
        }
    }
}
