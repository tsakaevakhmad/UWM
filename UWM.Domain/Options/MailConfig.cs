namespace UWM.Domain.Options
{
    public class MailConfig
    {
        public string Domain { get; set; }
        public int Port { get; set; }
        public bool SSL { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
