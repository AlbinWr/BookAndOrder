using BookAndOrder.Models;

namespace BookAndOrder.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<Product> FeaturedProducts { get; set; } = new List<Product>();
        public IEnumerable<Category> RandomCategories { get; set; } = new List<Category>();
    }
}
