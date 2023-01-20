using System.ComponentModel.DataAnnotations;

namespace UWM.Domain.DTO.Authentication
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
