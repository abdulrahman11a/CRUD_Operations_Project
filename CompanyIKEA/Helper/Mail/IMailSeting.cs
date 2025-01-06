using DAL.Entities.CoomonModel;

namespace CompanyIKEAPL.Helper.Mail
{
    public interface IMailSetting
    {
        Task SendMail(Email email,IList<IFormFile> files=null);
    }
}
