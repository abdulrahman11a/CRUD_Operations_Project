using DAL.Presistance.Repo._Genaric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Presistance.Repo.Employee
{
    public interface IEmployeeRepository:IGenaricRepository<Entities.Employee>
    {
    }
}
