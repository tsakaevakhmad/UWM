using System.ComponentModel.DataAnnotations;

namespace UWM.Domain.DTO.Authentication
{
    public class UserEmail
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
