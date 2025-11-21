namespace oop_workshop.src.Domain.Media
{
    public class Borrower : User
    {
        public Borrower(string name, int age, int ssn) : base(name, age, ssn)
        {
        }

        public void ListItems(List<Media> items, string type) {
            foreach (Media item in items)
            {
                if (item.GetType().Name == type)
                {
                    Console.WriteLine(item.title);
                }
            }

        }

        public void ViewDetails(string title, List<Media> items) {
            foreach (Media item in items)
            {
                if (item.title == title)
                {
                    try {
                        Console.WriteLine(item.ToString());
                        return;
                    } catch (Exception e) {
                        Console.WriteLine("Error displaying item info: " + e.Message);
                    }
                }
            }
            Console.WriteLine("Item not found.");
        }

        /*public void Rate(Media item, int rating) {
            if (rating < 1 || rating > 5) {
                Console.WriteLine("Rating must be between 1 and 5.");
                return;
            }
            try {
            item.AddRating(rating);
            } catch (Exception e) {
                Console.WriteLine("Error adding rating: " + e.Message);
                return;
            }
            Console.WriteLine($"You rated {item.title} with {rating} stars.");
        }*/
    }
    
}