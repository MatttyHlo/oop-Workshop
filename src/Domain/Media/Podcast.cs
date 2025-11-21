using oop_workshop.src.Domain.Interfaces;

namespace oop_workshop.src.Domain.Media
{
    class Podcast : Media, IDownloadable, IRatable
    {
        public int ReleaseYear { get; private set; }
        public string[] Hosts { get; private set; }
        public string[] Guests { get; private set; }
        public int EpisodeNumber { get; private set; }
        public string Language { get; private set; }

        public Podcast(string title, int releaseYear, string[] hosts, string[] guests, int episodeNumber, string language)
            : base(title)
        {
            ReleaseYear = releaseYear;
            Hosts = hosts;
            Guests = guests;
            EpisodeNumber = episodeNumber;
            Language = language;
        }

        public void Download(string url)
        {
            Console.WriteLine($"Downloading podcast episode '{title}' from {url}...");
        }

        public void Rate(int rating)
        {
            try {
                AddRating(rating);
                Console.WriteLine($"Rated podcast episode '{title}' with {rating} stars. Current average: {rating:F1}");
            } catch (Exception e) {
                Console.WriteLine("Error adding rating: " + e.Message);
            }
        }

        public void Listen()
        {
            Console.WriteLine($"Listening to podcast episode '{title}'.");
        }

        public void Complete()
        {
            Console.WriteLine($"Completed podcast episode '{title}'.");
        }

        public override string ToString()
        {
            return $"Podcast: {title}\n" +
                   $"  Release Year: {ReleaseYear}\n" +
                   $"  Hosts: {string.Join(", ", Hosts)}\n" +
                   $"  Guests: {string.Join(", ", Guests)}\n" +
                   $"  Episode Number: {EpisodeNumber}\n" +
                   $"  Language: {Language}\n" +
                   $"  Rating: {rating:F1}";
        }
    }
}
