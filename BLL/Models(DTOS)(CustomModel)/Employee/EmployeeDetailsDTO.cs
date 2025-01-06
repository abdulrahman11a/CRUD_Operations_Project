using DAL.CommonEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models_DTOS__CustomModel_.Employee
{
    public class EmployeeDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Address { get; set; } = null!;
        public decimal Salary { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Gender { get; set; }
        public string EmpType { get; set; }
        public bool IsActive { get; set; }
    }
}
