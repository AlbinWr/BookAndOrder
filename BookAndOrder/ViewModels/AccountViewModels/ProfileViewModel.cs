using System.ComponentModel.DataAnnotations;

namespace BookAndOrder.ViewModels.AccountViewModels
{
    public class ProfileViewModel
    {
        public string Email { get; set; }

        [Display(Name = "First name")]
        public string? FirstName { get; set; }

        [Display(Name = "Last name")]
        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        [Display(Name = "Adress")]
        public string? Address { get; set; }

        [Display(Name = "City")]
        public string? City { get; set; }

        [Display(Name = "Postcode")]
        public string? Postcode { get; set; }
    }
}
