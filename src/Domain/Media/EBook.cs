using oop_workshop.src.Domain.Interfaces;

namespace oop_workshop.src.Domain.Media
{
    class EBook : Media, IDownloadable, IRatable
    {
        public string Author { get; private set; }
        public string Language { get; private set; }
        public int NumberOfPages { get; private set; }
        public int YearOfPublication { get; private set; }
        public string ISBN { get; private set; }

        public EBook(string title, string author, string language, int numberOfPages, int yearOfPublication, string isbn)
            : base(title)
        {
            Author = author;
            Language = language;
            NumberOfPages = numberOfPages;
            YearOfPublication = yearOfPublication;
            ISBN = isbn;
        }

        public void Download(string url)
        {
            Console.WriteLine($"Downloading e-book '{title}' from {url}...");
        }

        public void Rate(int rating)
        {
            Console.WriteLine($"Rated e-book '{title}' with {rating} stars.");
        }

        public void View()
        {
            Console.WriteLine($"Viewing e-book '{title}'.");
        }

        public void Read()
        {
            Console.WriteLine($"Reading e-book '{title}'.");
        }

        public override string ToString()
        {
            return $"EBook: {title}\n" +
                   $"  Author: {Author}\n" +
                   $"  Language: {Language}\n" +
                   $"  Number of Pages: {NumberOfPages}\n" +
                   $"  Year of Publication: {YearOfPublication}\n" +
                   $"  ISBN: {ISBN}";
        }
    }
}
