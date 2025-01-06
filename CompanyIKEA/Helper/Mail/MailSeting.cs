//using DAL.Entities.CoomonModel;
//using Microsoft.Extensions.Options;
//using MimeKit;

//namespace CompanyIKEAPL.Helper.Mail
//{
//    public class MailSetting(IOptions<MailSetings> _emailSettings) : IMailSetting
//    {

     
//        public async Task SendMail(Email email, IList<IFormFile> files = null)
//        {
//            var Useremail = new MimeMessage // this MimeMessage contin only Sender , Subject
//            {
//                Sender = MailboxAddress.Parse(_emailSettings.Value.Email),
//                Subject = email.Subject
//            };

//            Useremail.To.Add(MailboxAddress.Parse(email.To));
//            var builder = new BodyBuilder(); //this intialize the bady if conten Attachment...this best practece if Eixt or not Attachment
//            Useremail.From.Add(new MailboxAddress(_emailSettings.Value.DisplayName, _emailSettings.Value.Email));

//            // Attach files if provided
//            if (files != null)
//            {
//                foreach (var file in files)
//                {
//                    using var ms = new MemoryStream();
//                    await file.CopyToAsync(ms);
//                    var fileBytes = ms.ToArray();
//                    builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
//                }
//            }

//            Useremail.Body = builder.ToMessageBody();

//            using var smtp = new MailKit.Net.Smtp.SmtpClient();//This Serervice for controll @gamail.com
//           await smtp.ConnectAsync(_emailSettings.Value.Host, _emailSettings.Value.Port, MailKit.Security.SecureSocketOptions.StartTls);            await smtp.AuthenticateAsync(_emailSettings.Value.Email, _emailSettings.Value.Password);
//            await smtp.SendAsync(Useremail);
//            await smtp.DisconnectAsync(true);
//        }
//    }
//}
