namespace Model.Entities
{
    public class Config
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
        public string? SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string? ImapServer { get; set; }
        public int ImapPort { get; set; }
    }
}
