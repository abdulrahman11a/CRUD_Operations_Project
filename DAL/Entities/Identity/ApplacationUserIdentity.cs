using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities.Identity
{
    public class ApplacationUserIdentity:IdentityUser
    {
        public bool isAgree {  get; set; }  

    }
}
