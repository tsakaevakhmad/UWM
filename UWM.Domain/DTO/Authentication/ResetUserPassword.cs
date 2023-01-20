using System.ComponentModel.DataAnnotations;

namespace UWM.Domain.DTO.Authentication
{
    public class ResetUserPassword
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Пароль должен быть не меньше 8 символов", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Пароль должен быть не меньше 8 символов", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public string Code { get; set; }
    }
}
