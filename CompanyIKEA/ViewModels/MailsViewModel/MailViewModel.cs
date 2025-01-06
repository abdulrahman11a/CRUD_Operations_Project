using System.ComponentModel.DataAnnotations;

namespace CompanyIKEAPL.ViewModels.MailsViewModel
{
    namespace CompanyIKEAPL.ViewModels.MailsViewModel
    {
        public class MailViewModel
        {
            [Required (ErrorMessage = "Is Required ")]
            public string To { get; set; }
            [Required(ErrorMessage = "Is Required ")]
            public string Subject { get; set; }
            public string Body { get; set; }
            public string From { get; set; }
            public IList<IFormFile> Attachment { get; set; } 

        }
    }

}
