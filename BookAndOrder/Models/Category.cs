using System.ComponentModel.DataAnnotations;

namespace BookAndOrder.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters.")]
        public string Name { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}