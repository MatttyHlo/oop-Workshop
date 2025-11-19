using oop_workshop.src.Domain.Interfaces;

namespace oop_workshop.src.Domain.Media
{
    class VideoGame : Media, IDownloadable, IPlayable, IRatable
    {
        public string Genre { get; private set; }
        public string Publisher { get; private set; }
        public int ReleaseYear { get; private set; }
        public string[] SupportedPlatforms { get; private set; }

        public VideoGame(string title, string genre, string publisher, int releaseYear, string[] supportedPlatforms)
        {
            this.title = title;
            Genre = genre;
            Publisher = publisher;
            ReleaseYear = releaseYear;
            SupportedPlatforms = supportedPlatforms;
        }

        public void Download(string url)
        {
            Console.WriteLine($"Downloading video game '{title}' from {url}...");
        }

        public void Rate(int rating)
        {
            Console.WriteLine($"Rated video game '{title}' with {rating} stars.");
        }

        public void Play()
        {
            Console.WriteLine($"Playing video game '{title}'.");
        }

        public void Complete()
        {
            Console.WriteLine($"Completed video game '{title}'.");
        }
    }
}
