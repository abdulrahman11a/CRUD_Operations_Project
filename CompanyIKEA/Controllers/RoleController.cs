using CompanyIKEAPL.ViewModels.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CompanyIKEAPL.Controllers
{
    public class RoleController(RoleManager<IdentityRole> _roleManager) : Controller
    {
  
        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleView)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(roleView.RoleName);
                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // Adjust the redirection as needed
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(nameof(AddRole));
        }
    }
}
