using System.ComponentModel.DataAnnotations;

namespace CompanyIKEAPL.ViewModels.Identity
{
    public class SignViewModel
    {

        [Required(ErrorMessage = "Email IsReQuired")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Password IsReQuired")]
        [DataType(DataType.Password)]    
        public string Password { get; set; }= null!;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; } 
    }
}
