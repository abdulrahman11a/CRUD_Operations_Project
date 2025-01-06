//using CompanyIKEAPL.Helper;
//using CompanyIKEAPL.Helper.Mail;
//using CompanyIKEAPL.ViewModels.MailsViewModel.CompanyIKEAPL.ViewModels.MailsViewModel;
//using Humanizer;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

//namespace CompanyIKEAPL.Controllers
//{
//    public class MailController(IMailSetting mail) : Controller
//    {

//        //[HttpGet]
//        //public IActionResult SendEmail()
//        //{
//        //    return View();
//        //}
//        [HttpPost]
//        public async Task<IActionResult> SendMail(MailViewModel mailView)
//        {
            
//            if (ModelState.IsValid)
//            {
//                var emailSettings = new Email()
//                {
//                    Subject ="Reset Password",


                    
//                };

//                // Send mail
//                await mail.SendMail(emailSettings, mailView.Attachment);
//                ViewBag.Message = "Email sent successfully!";
//                return RedirectToAction("Index", "Home");
//            }
//            else
//            {
//                ViewBag.Message = "Failed to send email. Please check the input fields.";
//            }

//            return View("SendEmail");
//        }
//    }
//}
