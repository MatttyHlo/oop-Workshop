namespace oop_workshop.src.Domain.Media
{
    public class Borrower : User
    {
        public List<Media> borrowed_media {get; private set;}

        public Borrower(string name, int age, int ssn) : base(name, age, ssn)
        {
            this.borrowed_media = new List<Media>();
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

        public void Borrow(string title, List<Media> items)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Invalid title.");
                return;
            }

            Media? found = null;
            foreach (Media m in items)
            {
                if (m.title == title)
                {
                    found = m;
                    break;
                }
            }

            if (found == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            if (borrowed_media.Contains(found))
            {
                Console.WriteLine($"You have already borrowed '{title}'.");
                return;
            }

            try
            {
                // remove from available collection and add to borrower's list
                items.Remove(found);
                borrowed_media.Add(found);
                Console.WriteLine($"Borrowed '{title}'.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error borrowing item: " + e.Message);
            }
        }

        public void Rate(Media item, int rating) {
            if (item == null)
            {
                Console.WriteLine("No item provided to rate.");
                return;
            }

            if (rating < 1 || rating > 5)
            {
                Console.WriteLine("Rating must be between 1 and 5.");
                return;
            }

            try
            {
                item.AddRating(rating);
                Console.WriteLine($"You rated '{item.title}' with {rating} stars. Current average: {item.rating:F1}");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding rating: " + e.Message);
            }
        }
    }
    
}