using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Authentication;
using UWM.Domain.DTO.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IAuthorizationServices _authorization;
        private readonly IConfiguration _configuration;

        public UserController(IUserServices userServices, IAuthorizationServices authorization, IConfiguration configuration) 
        {
            _userServices = userServices;
            _authorization = authorization;
            _configuration = configuration;
        }

        [HttpGet("UserInfo")]
        public async Task<UserInfo> GetUsersInfo()
        {
            var _userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return await _userServices.GetUserInfoAsync(_userEmail);
        }

        [HttpPut("ChangeEmail")]
        public async Task<bool> ChangeEmail(ChangeMail changeMail)
        {
            if (!ModelState.IsValid)
                return false;

            var _userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return await _userServices.ChangeMailAsync(_userEmail, changeMail.NewEmail, changeMail.Token);
        }

        [HttpPost("SendChangeToken")]
        public async Task<bool> SendChangeToken(NewMail newMail)
        {
            if(!ModelState.IsValid)
                return false;

            var _userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var token = await _userServices.MailChangeTokenAsync(_userEmail, newMail.NewEmail);

            var link = $"{_configuration.GetSection("Cors").Value.Split(",")[0]}/authorization/resetpassword?token={token}&email={newMail.NewEmail}";
            await _authorization.SendEmailAsync(newMail.NewEmail, "Смена почты", $"<p> Вам нужно перейти по <a href='{link}'>ссылке</a>");
            return true;
        }

        [HttpPut("ChangePassword")]
        public async Task<bool> ChangePassword(ChangePassword password)
        {
            if(!ModelState.IsValid)
                return false;

            var _userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return await _userServices.ChangePasswordAsync(_userEmail, password);
        }

        [HttpGet("User")]
        public async Task<UserDto> GetUser()
        {
            var _userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return await _userServices.UserInformationAsync(_userEmail);
        }
    }
}
