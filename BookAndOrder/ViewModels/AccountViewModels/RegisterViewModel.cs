using System.ComponentModel.DataAnnotations;

namespace BookAndOrder.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password must match.")]
        public string ConfirmPassword { get; set; }
    }
}
