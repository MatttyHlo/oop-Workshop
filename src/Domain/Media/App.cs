using oop_workshop.src.Domain.Interfaces;

namespace oop_workshop.src.Domain.Media
{
    class App : Media, IDownloadable, IRatable
    {
        public string Version { get; private set; }
        public string Publisher { get; private set; }
        public string[] SupportedPlatforms { get; private set; }
        public double FileSize { get; private set; }

        public App(string title, string version, string publisher, string[] supportedPlatforms, double fileSize)
            : base(title)
        {
            Version = version;
            Publisher = publisher;
            SupportedPlatforms = supportedPlatforms;
            FileSize = fileSize;
        }

        public void Download(string url)
        {
            Console.WriteLine($"Downloading app '{title}' from {url}...");
        }

        public void Rate(int rating)
        {
            try
            {
                AddRating(rating);
                Console.WriteLine($"Rated app '{title}' with {rating} stars. Current average: {(this.rating.HasValue ? this.rating.Value.ToString("F1") : "N/A")}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding rating: " + e.Message);
            }
        }

        public void Execute()
        {
            Console.WriteLine($"Executing app '{title}'.");
        }

        public override string ToString()
        {
            return $"App: {title}\n" +
                   $"  Version: {Version}\n" +
                   $"  Publisher: {Publisher}\n" +
                   $"  Supported Platforms: {string.Join(", ", SupportedPlatforms)}\n" +
                   $"  File Size: {FileSize} MB\n" +
                   $"  Rating: {(this.rating.HasValue ? this.rating.Value.ToString("F1") : "N/A")}";
        }
    }
}
