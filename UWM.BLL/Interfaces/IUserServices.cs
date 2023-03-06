using UWM.Domain.DTO.Authentication;
using UWM.Domain.DTO.User;

namespace UWM.BLL.Interfaces
{
    public interface IUserServices
    {
        public Task<UserDto> UserInformationAsync(string userEmail);
        public Task<bool> ChangePasswordAsync (string userEmail, ChangePassword password);
        public Task<bool> ChangeMailAsync(string userEmail, string newMail, string token);
        public Task<string> MailChangeTokenAsync(string userEmail, string newMail);
        public Task<UserInfo> GetUserInfoAsync(string userEmail);
    }
}
