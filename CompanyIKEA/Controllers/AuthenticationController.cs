using CompanyIKEAPL.ViewModels.Identity;
using DAL.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace CompanyIKEAPL.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<ApplacationUserIdentity> userManager;
        private readonly SignInManager<ApplacationUserIdentity> _signInManager;

        public AuthenticationController(UserManager<ApplacationUserIdentity> userManager, SignInManager<ApplacationUserIdentity> userRole)
        {
            this.userManager = userManager;
            this._signInManager = userRole;
        }
        #region SignUp
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
       // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            // Check if the model is valid
            if (!ModelState.IsValid)
                return View(model); // Return the view with the validation messages

            // Check if the username already exists
            var user = await userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                // Add a model error and return the view
                ModelState.AddModelError("", "Username is already taken.");
                return View(model);
            }

            // Create a new identity user
            var identity = new ApplacationUserIdentity
            {
                Email = model.Email,
                UserName = model.UserName,
                isAgree = model.isAgree,
            };

            // Attempt to create the user
            var res = await userManager.CreateAsync(identity, model.Password);//overload 1 its wor Password is prematve(Normal) Data
                                                                              // overload 2  ts wor Password is go Hash Password
            var res2 = await userManager.AddToRoleAsync(identity, "Admin"); 
            if (res.Succeeded)
            {
                // Optionally, assign the user to a default role, e.g., "User"
                //await userManager.AddToRoleAsync(identity, "User");

                // Redirect to the SignIn page or another action after successful sign-up
                return View(nameof(SignIn));
            }

            // If creation failed, add all the errors to the model state
            foreach (var error in res.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            // Return the view with the model to show any errors
            return View(model);
        }
        #endregion
   
          public IActionResult test()
        {
            if (User.Identity.IsAuthenticated == true) //User.Identity is  climes
            {
              string result =  User.Identity.Name;
              // var res= User.Claims//Department ,Employee عباره عن حاويه بيخزن فيها كل كليم زي  
              Claim id =User.Claims.FirstOrDefault(c=>c.Type== ClaimTypes.NameIdentifier);// for Id
                var resId = id.Value;//Becuse Dictinary

                var Email=User.Claims.FirstOrDefault(Em=>Em.Type== "Email");
                return Content(result);  
            }
            return Content("dd");


        }
        #region SgnIn
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    // Check if the user can sign in with the provided credentials
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: true);
                    List<Claim> c = new();
                    c.Add(new Claim("Email", model.Email));
                                                 // await _signInManager.SignInWithClaimsAsync(user, model.RememberMe, c);  Add calim
                    if (result.Succeeded)
                    {
                        // Redirect to the home page on successful login
                        return RedirectToAction("Index", "Home");
                    }
                    else if (result.IsLockedOut)
                    {
                        // Handle the case where the account is locked out
                        ModelState.AddModelError(string.Empty, "This account is locked. Please try again later.");
                    }
                    else if (result.IsNotAllowed)
                    {
                        // Handle the case where sign-in is not allowed (e.g., email not confirmed)
                        ModelState.AddModelError(string.Empty, "Sign-in is not allowed. Please check your email confirmation.");
                    }
                    else
                    {
                        // Handle invalid login attempts
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    }
                }
                else
                {
                    // Handle case when the email is not found
                    ModelState.AddModelError(string.Empty, "User not found.");
                }
            }

            // If the model is invalid or login failed, return the view with the model to show validation errors
            return View(model);
        }
        #endregion

        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(nameof(SignIn));   // for Remove Token 
        }

    }
}
