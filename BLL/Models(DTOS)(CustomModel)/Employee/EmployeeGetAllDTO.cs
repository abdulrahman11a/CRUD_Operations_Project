using System.ComponentModel.DataAnnotations;

namespace BLL.Models_DTOS__CustomModel_.Employee
{
    public class EmployeeGetAllDTO
    {
        public int Id { get; set; }

        public int Age { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Salary { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayFormat(DataFormatString = "{0}")]
        public string Email { get; set; }
    }
}
