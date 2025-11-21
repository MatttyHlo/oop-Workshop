using oop_workshop.src.Domain.Interfaces;

namespace oop_workshop.src.Domain.Media
{
    class Image : Media, IDownloadable, IRatable
    {
        public string Resolution { get; private set; }
        public string FileFormat { get; private set; }
        public double FileSize { get; private set; }
        public DateTime DateTaken { get; private set; }

        public Image(string title, string resolution, string fileFormat, double fileSize, DateTime dateTaken)
            : base(title)
        {
            Resolution = resolution;
            FileFormat = fileFormat;
            FileSize = fileSize;
            DateTaken = dateTaken;
        }

        public void Download(string url)
        {
            Console.WriteLine($"Downloading image '{title}' from {url}...");
        }

        public void Rate(int rating)
        {
            try {
                AddRating(rating);
                Console.WriteLine($"Rated image '{title}' with {rating} stars. Current average: {rating:F1}");
            } catch (Exception e) {
                Console.WriteLine("Error adding rating: " + e.Message);
            }
        }

        public void Display()
        {
            Console.WriteLine($"Displaying image '{title}'.");
        }

        public override string ToString()
        {
            return $"Image: {title}\n" +
                   $"  Resolution: {Resolution}\n" +
                   $"  File Format: {FileFormat}\n" +
                   $"  File Size: {FileSize} MB\n" +
                   $"  Date Taken: {DateTaken:yyyy-MM-dd}\n" +
                   $"  Rating: {rating:F1}";
        }
    }
}
