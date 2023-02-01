namespace UWM.Domain.DTO.Authentication
{
    public class UserInfo
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<string> UserRole { get; set; }
    }
}
