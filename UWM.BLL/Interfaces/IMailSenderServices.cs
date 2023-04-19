namespace UWM.BLL.Interfaces
{
    public interface IMailSenderServices
    {
        public Task SendEmailAsync(string email, string subject, string message);
    }
}
