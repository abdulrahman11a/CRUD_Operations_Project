using DAL.CommonEnum;
using DAL.Entities.CoomonModel;

namespace DAL.Entities
{
    public class Employee : ModelBase
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Address { get; set; } = null!;  
        public decimal Salary { get; set; }           
        public bool IsActive { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public Gender Gender { get; set; }
        public EmployeeType EmpType { get; set; }

        public int? DepartmentId { get; set; } 
        public Department ?Department { get; set; }

     
    }
}
