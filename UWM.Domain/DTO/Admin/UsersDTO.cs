namespace UWM.Domain.DTO.Admin
{
    public class UsersDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string Phone { get; set; }
        public List<string> UserRole { get; set; }
    }
}
