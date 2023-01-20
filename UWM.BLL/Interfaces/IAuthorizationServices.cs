using UWM.Domain.DTO.Authentication;

namespace UWM.BLL.Interfaces
{
    public interface IAuthorizationServices
    {
        public Task<TokenOrMailConfirme> Login(Login login);
        public Task<RegistrationSuccsess> Registration(Registration registration);
        public Task SendEmailAsync(string email, string subject, string message);
        public Task<bool> ConfirmEmail(string userEmail, string code);
        public Task<string> ForgotPassword(UserEmail model);
        public Task<bool> ResetPassword(ResetUserPassword model);
    }
}
