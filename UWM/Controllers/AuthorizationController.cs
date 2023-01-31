using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Authentication;

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuthorizationServices _authorizationServices;
        private readonly IConfiguration _configuration;

        public AuthorizationController(SignInManager<IdentityUser> signInManager, IAuthorizationServices authorizationServices, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _authorizationServices = authorizationServices;
            _configuration = configuration;
        }

        // POST api/Authorization/Login
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await _authorizationServices.Login(login);
                
                if(result == null)
                    return Unauthorized(new { Error = "Password or Mail wrong" });

                if (!string.IsNullOrEmpty(result.Token))
                {
                    return Ok(new { Token = result.Token });
                }
                else if (!string.IsNullOrEmpty(result.Code))
                {
                    SendMailToConfirm(login.Email, result.Code);
                    return Content("Ваша регистрация не завршена. Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }
                return Unauthorized();
            }
            return BadRequest();
        }

        // POST api/Authorization/Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        // POST api/Authorization/ForgotPassword
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(UserEmail email)
        {
            var code = await _authorizationServices.ForgotPassword(email);
            var link = $"{_configuration.GetSection("Cors").Value.Split(",")[0]}/authorization/resetpassword?code={code}";
            await _authorizationServices.SendEmailAsync(email.Email, 
                "Подтвержение аккаунта", $"<p> Вам нужно перейти по <a href='{link}'>ссылке</a>");
            return Ok("Вам на почту был выслан КЛЮЧ для сброса пароля");
        }

        // POST api/Authorization/ResetPassword
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetUserPassword model)
        {
            if(!ModelState.IsValid)
                return BadRequest("Модель неправильно заполнина");
            return Ok(await _authorizationServices.ResetPassword(model));
        }

        // POST api/Authorization/Register
        [HttpPost("Register")]
        public async Task<IActionResult> Registeration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                var user = await _authorizationServices.Registration(registration);
                if (user != null)
                {
                    SendMailToConfirm(user.Email, user.Code);
                    return Content("Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }
                return BadRequest();
            }
            return BadRequest();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<bool> ConfirmEmail(ConfirmAccaunt confirm)
        {
            var url = _configuration.GetSection("CORS").Value.Split(",")[0];
            var result = await _authorizationServices.ConfirmEmail(confirm.Email, confirm.Code);
            if (result == true)
            {
                await _authorizationServices.SendEmailAsync(confirm.Email, "Ваша аккаунт подтвержден", "Поздравляем вы успешно подтвердили свою учетную запись");
                return true;
            }
            return false;
        }

        private async void SendMailToConfirm(string email, string code)
        {
            var link = $"{_configuration.GetSection("Cors").Value.Split(",")[0]}/authorization/confirmaccaunt?email={email}&code={code}";

            await _authorizationServices.SendEmailAsync(email, "Подтверждение аккаунта",
                $"Подтвердите сброс пароля, перейдя по ссылке: <a href='{link}'>Подтвердить</a>");
        }
    }
}
