using System.ComponentModel.DataAnnotations;

namespace CompanyIKEAPL.ViewModels.Identity
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "User Name Is Required")]
        public string UserName { get; set; } = null!;
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        [Compare("Password", ErrorMessage="Must Password Match")]   
        public string ConfirmPassword { get; set; } = null!;
        public bool isAgree { get; set; }


    }
}
