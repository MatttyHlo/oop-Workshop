namespace oop_workshop.src.Domain.Media
{
    class Podcast : Media
    {
        public int ReleaseYear { get; private set; }
        public string[] Hosts { get; private set; }
        public string[] Guests { get; private set; }
        public int EpisodeNumber { get; private set; }
        public string Language { get; private set; }

        public Podcast(string title, int releaseYear, string[] hosts, string[] guests, int episodeNumber, string language)
        {
            this.title = title;
            ReleaseYear = releaseYear;
            Hosts = hosts;
            Guests = guests;
            EpisodeNumber = episodeNumber;
            Language = language;
        }
    }
}
