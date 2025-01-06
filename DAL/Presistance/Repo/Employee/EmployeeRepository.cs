using DAL.Presistance.DATA.AppDbContext;
using DAL.Presistance.Repo._Genaric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Presistance.Repo.Employee
{
    public class EmployeeRepository : GenaricRepository<Entities.Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext aplacationDebcontext) : base(aplacationDebcontext)
        {
        }
    }
}
