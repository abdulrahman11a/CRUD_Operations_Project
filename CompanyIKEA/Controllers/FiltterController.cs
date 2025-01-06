using CompanyIKEAPL.Filtters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CompanyIKEAPL.Controllers
{
    [Authorize]
    public class FiltterController : Controller
    {
       // [AllowAnonymous]// this is Filtter  Default any Action  Ex
       // iF All Action in controller is Authrize Unless one Acution set this Fillter 
        [HandelException]
        public IActionResult Index()
        {
            throw new Exception();
        }
    }
}
