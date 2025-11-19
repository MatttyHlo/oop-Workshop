namespace oop_workshop.src.Domain.Media
{
    class EBook : Media
    {
        public string Author { get; private set; }
        public string Language { get; private set; }
        public int NumberOfPages { get; private set; }
        public int YearOfPublication { get; private set; }
        public string ISBN { get; private set; }

        public EBook(string title, string author, string language, int numberOfPages, int yearOfPublication, string isbn)
        {
            this.title = title;
            Author = author;
            Language = language;
            NumberOfPages = numberOfPages;
            YearOfPublication = yearOfPublication;
            ISBN = isbn;
        }
    }
}
