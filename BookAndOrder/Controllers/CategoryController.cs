using BookAndOrder.Interfaces;
using BookAndOrder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookAndOrder.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IProductRepository _productRepo;

        public CategoryController(ICategoryRepository categoryRepo, IProductRepository productRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryRepo.GetAllAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepo.AddAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepo.GetByIdAsync(id);
            if (category != null)
            {
                var products = await _productRepo.GetByCategoryIdAsync(id);
                if (products.Any())
                {
                    TempData["ErrorMessage"] = "Cannot delete category with associated products.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    await _categoryRepo.DeleteAsync(id);
                    TempData["SuccessMessage"] = "Category removed!";
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
