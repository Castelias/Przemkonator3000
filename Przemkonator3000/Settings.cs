namespace Przemkonator3000
{
    public static class Settings
    {
        public static int ImapPort { get; set; } = 993;
        public static int SmtpPort { get; set; } = 587;
        public static string ImapHost { get; set; } = "outlook.office365.com";
        public static string SmtpHost { get; set; } = "smtp.poczta.onet.pl";
    }
}
