using Microsoft.AspNetCore.Mvc;
using BookAndOrder.Interfaces;

namespace BookAndOrder.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, string productName, int? quantity)
        {
            try
            {
                await _cartService.AddToCartAsync(id, quantity ?? 1);
                TempData["SuccessMessage"] = $"{productName} added to cart!";
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            var referer = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(referer))
            {
                return Redirect(referer);
            }

            return RedirectToAction("Index", "Products");
        }

        public IActionResult RemoveFromCart(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            _cartService.ClearCart();
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseQuantity(int id)
        {
            _cartService.DecreaseQuantity(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> IncreaseQuantity(int id)
        {
            try
            {
                await _cartService.IncreaseQuantityAsync(id);
            }
            catch (InvalidOperationException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("Index");
        }
    }
}
