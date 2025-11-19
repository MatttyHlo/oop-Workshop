namespace oop_workshop.src.Domain.Media
{
    class Movie : Media
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
    }
}
