using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UWM.BLL.Interfaces;
using UWM.Domain.DTO.Authentication;
using UWM.Domain.JWT;
using UWM.Domain.Options;

namespace UWM.BLL.Services
{
    public class AuthorizationServices : IAuthorizationServices
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly JWTSettings _options;
        private readonly MailConfig _mailOptions;

        public AuthorizationServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IOptions<JWTSettings> options, IOptions<MailConfig> mailOptions) 
        { 
            _userManager = userManager;
            _signInManager = signInManager;
            _options = options.Value;
            _mailOptions = mailOptions.Value;
        }

        public async Task<TokenOrMailConfirme> Login(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null)
            {
                if (user.EmailConfirmed == true)
                {
                    var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, login.Password, false);
                    if (passwordCheck.Succeeded)
                    {
                        var token = await GetToken(user);

                        UserInfo userInfo = new UserInfo
                        {
                            Id = user.Id,
                            UserName = user.UserName,
                            UserRole = _userManager.GetRolesAsync(user).Result.ToList()
                        };
                        return new TokenOrMailConfirme { Token = new JwtSecurityTokenHandler().WriteToken(token), UserInfo = userInfo };
                    }
                    return null;
                }
                else
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    return new TokenOrMailConfirme { Code = code };
                }
            }
            return null;
        }

        public async Task<RegistrationSuccsess> Registration(Registration registration)
        {
            var existingUser = await _userManager.FindByEmailAsync(registration.Email);
            if (existingUser == null)
            {
                IdentityUser user = new IdentityUser() { UserName = registration.UserName, Email = registration.Email };
                IdentityResult result = _userManager.CreateAsync(user, registration.Password).Result;
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    return new RegistrationSuccsess { Email = registration.Email, Password = registration.Password, UserName = registration.UserName, Code = code };
                }
                return null;
            }
            return null;
        }

        private async Task<JwtSecurityToken> GetToken(IdentityUser user)
        {
            var x = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>()
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),   
                        };
            foreach (var c in x)
                claims.Add(new Claim(ClaimTypes.Role, c));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _options.Issuer,
                audience: _options.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(12),
                notBefore: DateTime.UtcNow,
                signingCredentials: credentials
                );
            return token;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", _mailOptions.Mail));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_mailOptions.Domain, _mailOptions.Port, _mailOptions.SSL);
                await client.AuthenticateAsync(_mailOptions.Mail, _mailOptions.Password);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }

        public async Task<string> ForgotPassword(UserEmail model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);    
            if (user == null || user.EmailConfirmed != true)
                return null;

            string code = await _userManager.GeneratePasswordResetTokenAsync(user);
            return code;
        }

        public async Task<bool> ResetPassword(ResetUserPassword model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return false;

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            return result.Succeeded;
        }

        public async Task<bool> ConfirmEmail(string userEmail, string code)
        {
            if (userEmail == null || code == null)
                return false;

            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user == null)
                return false;

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return true;
            return false;
        }
    }
}
