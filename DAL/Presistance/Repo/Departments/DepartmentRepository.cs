using DAL.Entities;
using DAL.Presistance.DATA.AppDbContext;
using DAL.Presistance.DATA.DataSeed;
using DAL.Presistance.Repo._Genaric;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Presistance.Repo.Departments
{
    public class DepartmentRepository : GenaricRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(ApplicationDbContext aplacationDebcontext) : base(aplacationDebcontext)
        {
        }
    }
}
