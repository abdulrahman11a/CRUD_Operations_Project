using BLL.Models_DTOS__CustomModel_.Employee.Common_Dato;
using DAL.CommonEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models_DTOS__CustomModel_.Employee
{
    public class EmployeeUpdateDto:CommonCreateAndUpdate
    {
        public int Id { get; set; }
     
    }
}
