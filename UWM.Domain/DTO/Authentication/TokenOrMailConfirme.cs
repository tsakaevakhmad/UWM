namespace UWM.Domain.DTO.Authentication
{
    public class TokenOrMailConfirme
    {
        public string Token { get; set; }
        public List<string> Roles { get; set; }
        public string Code { get; set; }
    }
}