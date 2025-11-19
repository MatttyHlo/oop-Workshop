namespace oop_workshop.src.Domain.Media
{
    public class Media
    {
        public string title { get; private set; }
        private List<int> ratings = new List<int>();
        
        public Media(string title)
        {
            this.title = title;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Title: {title}");
            if (ratings.Count > 0)
            {
                double avgRating = ratings.Average();
                Console.WriteLine($"Average Rating: {avgRating:F2} ({ratings.Count} ratings)");
            }
            else
            {
                Console.WriteLine("No ratings yet");
            }
        }

        public void AddRating(int rating)
        {
            if (rating < 1 || rating > 5)
            {
                throw new ArgumentException("Rating must be between 1 and 5");
            }
            ratings.Add(rating);
        }
    }
}