using System.ComponentModel.DataAnnotations;

namespace CompanyIKEAPL.ViewModels.Role
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Role is Requierd")]
        [Display (Name = "Role Name")]
        public string RoleName{  get; set; }
    }
}
