using oop_workshop.src.Domain.Interfaces;

namespace oop_workshop.src.Domain.Media
{
    class Movie : Media, IDownloadable, IRatable
    {
        public string Director { get; private set; }
        public string[] Genres { get; private set; }
        public int ReleaseYear { get; private set; }
        public string Language { get; private set; }
        public int Duration { get; private set; }

        public Movie(string title, string director, string[] genres, int releaseYear, string language, int duration)
        {
            this.title = title;
            Director = director;
            Genres = genres;
            ReleaseYear = releaseYear;
            Language = language;
            Duration = duration;
        }

        public void Download(string url)
        {
            Console.WriteLine($"Downloading movie '{title}' from {url}...");
        }

        public void Rate(int rating)
        {
            Console.WriteLine($"Rated movie '{title}' with {rating} stars.");
        }

        public void Watch()
        {
            Console.WriteLine($"Watching movie '{title}'.");
        }
    }
}
