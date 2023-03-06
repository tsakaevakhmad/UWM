namespace UWM.Domain.DTO.User
{
    public class ChangePassword
    {
        public string CurrentPassword { get; set; }
        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }
    }
}
