using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppDemo4._0.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage ="Name limit exeeded")]
        [Required]
        public string Name { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",ErrorMessage ="invalid email format")]
        [Required]
        [Display(Name ="Office Mail",Prompt ="select")]
        public string Email { get; set; }
        [Required]
        public Dept? Department { get; set;}
        public string PhotoPath { get; set; }

    }
}
