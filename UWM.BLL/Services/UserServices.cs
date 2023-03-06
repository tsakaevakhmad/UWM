using Microsoft.AspNetCore.Identity;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Authentication;
using UWM.Domain.DTO.User;

namespace UWM.BLL.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserServices(UserManager<IdentityUser> userManager) 
        {
            _userManager = userManager;
        }

        public async Task<bool> ChangeMailAsync(string userEmail, string newMail, string token)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userEmail);
                await _userManager.ChangeEmailAsync(user, newMail, token);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<string> MailChangeTokenAsync(string userEmail, string newMail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            return await _userManager.GenerateChangeEmailTokenAsync(user, newMail);
        }

        public async Task<UserInfo> GetUserInfoAsync(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var userRoles = await _userManager.GetRolesAsync(user);
            return new UserInfo { Id = user.Id, UserName = user.UserName, UserRoles = (List<string>)userRoles };
        }

        public async Task<bool> ChangePasswordAsync(string userEmail, ChangePassword password)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(userEmail);
                await _userManager.ChangePasswordAsync(user, password.CurrentPassword, password.Password);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<UserDto> UserInformationAsync(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                UserEmail = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                Roles = (List<string>) await _userManager.GetRolesAsync(user)
            };
        }
    }
}
