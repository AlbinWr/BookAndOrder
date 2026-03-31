using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAndOrder.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [RegularExpression(@".*[a-zA-ZåäöÅÄÖ].*", ErrorMessage = "Product name must contain at least one letter.")]
        [StringLength(50, ErrorMessage = "Product name cannot exceed 50 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Product description is required.")]
        [MinLength(10, ErrorMessage = "Product description must be at least 10 characters long.")]
        [MaxLength(500, ErrorMessage = "Product description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Product price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Product stock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Product stock cannot be negative.")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Choose a category.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }

        [ValidateNever]
        public Category? Category { get; set; }

        [ValidateNever]
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}