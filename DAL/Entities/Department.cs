using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities.CoomonModel;

namespace DAL.Entities
{
    public class Department : ModelBase
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Code { get; set; }
        public DateOnly CreationDate { get; set; }
        public ICollection<Employee> Employees { get; set; }= new HashSet<Employee>();
        //does not allow duplicate elements. In this context, 
        //A HashSet<T> provides O(1) (constant time) 
        //List<T> would take O(n) (linear time) to check for an existing



    }
}
