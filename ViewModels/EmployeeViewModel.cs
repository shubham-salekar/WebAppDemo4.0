using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using WebAppDemo4._0.Models;

namespace WebAppDemo4._0.ViewModels
{
    public class EmployeeViewModel
    {
        [MaxLength(50, ErrorMessage = "Name limit exeeded")]
        [Required]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "invalid email format")]
        [Required]
        [Display(Name = "Office Mail", Prompt = "select")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
