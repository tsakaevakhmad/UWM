using System.ComponentModel.DataAnnotations;

namespace UWM.Domain.DTO.User
{
    public class ChangePassword
    {
        [Required]
        public string CurrentPassword { get; set; }
        
        [Required]
        [StringLength(255, ErrorMessage = "Пароль должен быть не меньше 8 символов", MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmedPassword { get; set; }
    }
}
