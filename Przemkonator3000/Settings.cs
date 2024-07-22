using Newtonsoft.Json;

namespace Przemkonator3000
{
    public sealed class Settings
    {
        private static readonly Lazy<Settings> lazy = new(() => new Settings());
        private readonly string _filePath;

        public static Settings Instance { get { return lazy.Value; } }

        public int ImapPort { get; set; }
        public int SmtpPort { get; set; }
        public string ImapHost { get; set; }
        public string SmtpHost { get; set; }

        private Settings()
        {
            _filePath = GetSettingsFilePath();
        }

        public void LoadSettings()
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                var settings = JsonConvert.DeserializeObject<Settings>(json);

                ImapPort = settings.ImapPort;
                SmtpPort = settings.SmtpPort;
                ImapHost = settings.ImapHost;
                SmtpHost = settings.SmtpHost;

                Console.WriteLine("Settings have been loaded from " + _filePath);
            }
            else
            {
                Console.WriteLine("File not found: " + _filePath);
            }
        }

        public void SaveSettings()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(_filePath, json);
        }

        public void LoadDefaultSettings()
        {
            ImapPort = 993;
            SmtpPort = 587;
            ImapHost = "imap.poczta.onet.pl ";
            SmtpHost = "smtp.poczta.onet.pl";
        }

        private static string GetSettingsFilePath()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string settingsDirectory = Path.Combine(appDataPath, "MyApplication");
            if (!Directory.Exists(settingsDirectory))
            {
                Directory.CreateDirectory(settingsDirectory);
            }
            return Path.Combine(settingsDirectory, "settings.json");
        }
    }
}
