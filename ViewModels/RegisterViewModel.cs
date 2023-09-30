using System.ComponentModel.DataAnnotations;

namespace WebAppDemo4._0.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password   { get; set; }
        [Required]
        [Display(Name="Confirm Passord")]   
        [Compare("Password",ErrorMessage ="Password not match")]
        public string ConfirmPassword { get; set; }
    }
}
