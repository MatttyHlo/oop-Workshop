namespace oop_workshop.src.Domain.Media
{
    class Image : Media
    {
        public string Resolution { get; private set; }
        public string FileFormat { get; private set; }
        public double FileSize { get; private set; }
        public DateTime DateTaken { get; private set; }

        public Image(string title, string resolution, string fileFormat, double fileSize, DateTime dateTaken)
        {
            this.title = title;
            Resolution = resolution;
            FileFormat = fileFormat;
            FileSize = fileSize;
            DateTaken = dateTaken;
        }
    }
}
