namespace UWM.Domain.DTO.Authentication
{
    public class TokenOrMailConfirme
    {
        public string Token { get; set; }
        public UserInfo UserInfo { get; set; }
        public string Code { get; set; }
    }
}