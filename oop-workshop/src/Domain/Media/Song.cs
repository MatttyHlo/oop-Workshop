namespace oop_workshop.src.Domain.Media
{
    class Song : Media
    {
        public string Composer { get; private set; }
        public string Singer { get; private set; }
        public string Genre { get; private set; }
        public string FileType { get; private set; }
        public int Duration { get; private set; }
        public string Language { get; private set; }

        public Song(string title, string composer, string singer, string genre, string fileType, int duration, string language)
        {
            this.title = title;
            Composer = composer;
            Singer = singer;
            Genre = genre;
            FileType = fileType;
            Duration = duration;
            Language = language;
        }
    }
}
