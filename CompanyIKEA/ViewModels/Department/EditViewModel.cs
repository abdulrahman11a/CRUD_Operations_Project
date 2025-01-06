using System.ComponentModel.DataAnnotations;

namespace CompanyIKEAPL.ViewModels.Department
{
    public class EditViewModel
    {
        [Required(ErrorMessage = "The Name is Required")]
        public string Name { get; set; }
        public string? Description { get; set; }

        public string Code { get; set; }

        [Required(ErrorMessage = "The Creation Date is Required")]
        public DateOnly CreationDate { get; set; }



    }
}
