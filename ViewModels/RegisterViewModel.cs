using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAppDemo4._0.ValidationAttributes;

namespace WebAppDemo4._0.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [ValidEmailDomain(allowDomain:"c2w.com",ErrorMessage ="Email Domain should be c2w.com")]
        [Remote(action: "IsEmailInUse", controller: "account")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password   { get; set; }
        [Required]
        [Display(Name="Confirm Passord")]   
        [Compare("Password",ErrorMessage ="Password not match")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
    }
}
