using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UWM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuthorizationServices _authorizationServices;
        public AuthorizationController(SignInManager<IdentityUser> signInManager, IAuthorizationServices authorizationServices)
        {
            _signInManager = signInManager;
            _authorizationServices = authorizationServices;
        }

        // POST api/Authorization/Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            if (ModelState.IsValid)
            {
                var result = await _authorizationServices.Login(login);
                if (result.Token != null)
                {
                    return Ok(new { Token = result.Token });
                }
                else if (result.Code != null)
                {
                    SendMailToConfirm(login.Email, result.Code);
                    return Content("Ваша регистрация не завршена. Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
                }
                return Unauthorized();
            }
            return BadRequest();
        }

        private async void SendMailToConfirm(string email, string code)
        {
            var callbackUrl = Url.Action(
                                            "ConfirmEmail",
                                            "Authorization",
                                            new { userName = email, code = code },
                                            protocol: HttpContext.Request.Scheme);
            
            await _authorizationServices.SendEmailAsync(email, "Confirm your account",
                $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callbackUrl}'>Подтвердить</a>");
        }

        // POST api/Authorization/Logout
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        // POST api/Authorization/Register
        [HttpPost("register")]
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userName, string code)
        {
            var result = await _authorizationServices.ConfirmEmail(userName, code);
            if (result == true)
                return Ok("Успешно");
            else
                return BadRequest();
        }
    }
}
