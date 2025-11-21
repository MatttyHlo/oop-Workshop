using oop_workshop.src.Domain.Interfaces;

namespace oop_workshop.src.Domain.Media
{
    class Song : Media, IDownloadable, IRatable
    {
        public string Composer { get; private set; }
        public string Singer { get; private set; }
        public string Genre { get; private set; }
        public string FileType { get; private set; }
        public int Duration { get; private set; }
        public string Language { get; private set; }

        public Song(string title, string composer, string singer, string genre, string fileType, int duration, string language)
            : base(title)
        {
            Composer = composer;
            Singer = singer;
            Genre = genre;
            FileType = fileType;
            Duration = duration;
            Language = language;
        }

        public void Download(string url)
        {
            Console.WriteLine($"Downloading song '{title}' from {url}...");
        }

        public void Rate(int rating)
        {
            Console.WriteLine($"Rated song '{title}' with {rating} stars.");
        }

        public void Play()
        {
            Console.WriteLine($"Playing song '{title}'.");
        }

        public void Pause()
        {
            Console.WriteLine($"Paused song '{title}'.");
        }

        public void Stop()
        {
            Console.WriteLine($"Stopped song '{title}'.");
        }

        public override string ToString()
        {
            return $"Song: {title}\n" +
                   $"  Composer: {Composer}\n" +
                   $"  Singer: {Singer}\n" +
                   $"  Genre: {Genre}\n" +
                   $"  File Type: {FileType}\n" +
                   $"  Duration: {Duration} seconds\n" +
                   $"  Language: {Language}";
        }
    }
}
