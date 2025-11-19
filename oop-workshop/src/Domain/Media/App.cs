namespace oop_workshop.src.Domain.Media
{
    class App : Media
    {
        public string Version { get; private set; }
        public string Publisher { get; private set; }
        public string[] SupportedPlatforms { get; private set; }
        public double FileSize { get; private set; }

        public App(string title, string version, string publisher, string[] supportedPlatforms, double fileSize)
        {
            this.title = title;
            Version = version;
            Publisher = publisher;
            SupportedPlatforms = supportedPlatforms;
            FileSize = fileSize;
        }
    }
}
