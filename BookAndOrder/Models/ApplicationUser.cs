using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookAndOrder.Models
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(20)]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\s-]+$", ErrorMessage = "Names can only contain letters")]
        public string? FirstName { get; set; }

        [StringLength(30)]
        [RegularExpression(@"^[a-zA-ZåäöÅÄÖ\s-]+$", ErrorMessage = "Names can only contain letters")]
        public string? LastName { get; set; }

        [StringLength(50)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [RegularExpression(@"^\d{3}\s?\d{2}$", ErrorMessage = "Invalid postcode format.")]
        public string? Postcode { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
