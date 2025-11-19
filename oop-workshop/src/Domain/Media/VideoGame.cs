namespace oop_workshop.src.Domain.Media
{
    class VideoGame : Media
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
    }
}
