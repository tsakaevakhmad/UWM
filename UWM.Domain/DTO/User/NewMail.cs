using System.ComponentModel.DataAnnotations;

namespace UWM.Domain.DTO.User
{
    public class NewMail
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string NewEmail { get; set; }
    }
}
