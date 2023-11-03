using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppDemo4._0.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }
        [Required(ErrorMessage = "Required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }
}
