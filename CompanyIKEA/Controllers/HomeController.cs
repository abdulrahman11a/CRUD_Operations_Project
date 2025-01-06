using CompanyIKEAPL.ViewModels.Commn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CompanyIKEA.Controllers
{
    [Authorize(AuthenticationSchemes ="Identity.Application")] //this Men Token Must Genareted  from this "Identity.Application"

    // Authorize("Admin,User")]   this Mens Role has Admin Or User Any one is true this same RelationAnd OR

    //[Authorize("Admin ")]  { Tis Must contain two not}this same RelationAnd
    //[Authorize("User")]
    //policy mean how call this  iam Detrmanit hwo call this tha Support Scuerty more
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

