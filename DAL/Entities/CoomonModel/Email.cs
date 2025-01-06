using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.CoomonModel
{
    public class Email 
    {
        public  int Id { get; set; } // If Busnas Wont Save Email in  DataBase 
        public string Subject { get; set; }
        public string Body { get; set; }
        public string To { get; set; }





    }
}
