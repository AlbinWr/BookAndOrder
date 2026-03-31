using BookAndOrder.Interfaces;
using BookAndOrder.Models;
using BookAndOrder.ViewModels.ProductViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace BookAndOrder.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(IProductRepository productRepo, IRepository<Category> categoryRepo, IWebHostEnvironment webHostEnvironment)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(string searchString, int? categoryId)
        {
            ViewData["CurrentFilter"] = searchString;

            //Fetch data using repo
            var products = await _productRepo.GetAllAsync(searchString, categoryId);

            //Pass categories to the view for dropdown filter
            ViewBag.Categories = await _categoryRepo.GetAllAsync();
            ViewBag.SelectedCategory = categoryId;

            //Map products to view models
            var viewModelList = products.Select(product => new ProductViewModel
            {
                Id = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryName = product.Category?.Name ?? "Uncategorized",
                ImageUrl = product.ImageUrl
            }).ToList();

            return View(viewModelList);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            await PopulateCategoriesAsync();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.Image != null)
                {
                    product.ImageUrl = await SaveImageAsync(product.Image);
                }

                await _productRepo.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            await PopulateCategoriesAsync();
            return View(product);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            //Fetch product and related category data
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailsViewModel
            {
                Id = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                CategoryName = product.Category?.Name ?? "Uncategorized",
                ImageUrl = product.ImageUrl,
                Stock = product.Stock
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product != null)
            {
                DeleteImage(product.ImageUrl);
                await _productRepo.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepo.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var ViewModel = new ProductEditViewModel
            {
                Id = product.ProductId,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                CategoryId = product.CategoryId,
                ImageUrl = product.ImageUrl
            };
            await PopulateCategoriesAsync();
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(ProductEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var product = await _productRepo.GetByIdAsync(viewModel.Id);
                if (product == null)
                {
                    return NotFound();
                }

                //Update product properties
                product.Name = viewModel.Name;
                product.Description = viewModel.Description;
                product.Price = viewModel.Price;
                product.Stock = viewModel.Stock;
                product.CategoryId = viewModel.CategoryId;

                //If user uploads new image, remove the old image
                if (viewModel.NewImage != null)
                {
                    DeleteImage(product.ImageUrl);
                    product.ImageUrl = await SaveImageAsync(viewModel.NewImage);
                }
                await _productRepo.UpdateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            await PopulateCategoriesAsync();
            return View(viewModel);
        }

        private async Task<string> SaveImageAsync(IFormFile image)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string uploadsFolder = Path.Combine(wwwRootPath, "images", "products");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
            string filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return "/images/products/" + fileName;
        }

        // Methods
        private async Task PopulateCategoriesAsync()
        {
            ViewBag.CategoryList = await _categoryRepo.GetAllAsync();
        }

        private void DeleteImage(string? imageUrl)
        {
            if (!string.IsNullOrEmpty(imageUrl))
            {
                string filePath = Path.Combine(_webHostEnvironment.WebRootPath, imageUrl.TrimStart('/'));
                if (System.IO.File.Exists(filePath))
                {
                    try
                    {
                        System.IO.File.Delete(filePath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Image delete failed: {ex.Message}");
                    }
                }
            }
            return;
        }
    }
}

