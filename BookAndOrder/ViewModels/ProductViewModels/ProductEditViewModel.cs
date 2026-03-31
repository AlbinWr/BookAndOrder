using System.ComponentModel.DataAnnotations;

namespace BookAndOrder.ViewModels.ProductViewModels
{
    public class ProductEditViewModel : ProductViewModel
    {

        [Required(ErrorMessage = "Please select a category.")]
        public int CategoryId { get; set; }
        public IFormFile? NewImage { get; set; }
    }
}
