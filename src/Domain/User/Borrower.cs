namespace oop_workshop.src.Domain.User
{
    using oop_workshop.src.Domain.Media;
    
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

        public void Organize(List<Media> items, string criteria)
        {
            if (items == null || items.Count == 0)
            {
                Console.WriteLine("No items to organize.");
                return;
            }

            if (string.IsNullOrWhiteSpace(criteria))
            {
                Console.WriteLine("No sorting criteria provided.");
                return;
            }

            IComparer<Media>? comparer = null;
            string sortDescription = criteria;
            string criteriaLower = criteria.ToLower().Trim();
            string propertyToCheck = criteria;

            if (criteriaLower == "rating")
            {
                comparer = new RatingComparer();
                sortDescription = "Rating (Highest First)";
                propertyToCheck = "rating";
            }
            else if (criteriaLower == "year" || criteriaLower == "releaseyear" || criteriaLower == "yearofpublication")
            {
                comparer = new GenericMediaComparer("ReleaseYear", descending: true);
                sortDescription = "Year (Most Recent First)";
                propertyToCheck = "ReleaseYear";
            }
            else
            {
                comparer = new GenericMediaComparer(criteria, descending: false);
                sortDescription = $"{criteria} (A-Z / Ascending)";
                propertyToCheck = criteria;
            }

            try
            {
                List<Media> filteredList = new List<Media>();
                
                if (propertyToCheck.ToLower() == "rating")
                {
                    foreach (Media item in items)
                    {
                        if (item.rating.HasValue)
                        {
                            filteredList.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (Media item in items)
                    {
                        var propertyValue = GetPropertyValue(item, propertyToCheck);
                        if (propertyValue != null)
                        {
                            filteredList.Add(item);
                        }
                    }
                }

                if (filteredList.Count == 0)
                {
                    Console.WriteLine($"\nNo items found with property '{propertyToCheck}'.");
                    return;
                }

                filteredList.Sort(comparer);

                Console.WriteLine($"\n--- Media List Organized by {sortDescription} ---");
                foreach (Media item in filteredList)
                {
                    string ratingStr = item.rating.HasValue ? $"{item.rating.Value:F1}" : "N/A";
                    Console.WriteLine($"[{item.GetType().Name}] {item.title} (Rating: {ratingStr})");
                }
                Console.WriteLine($"--- Total: {filteredList.Count} items ---\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error organizing media list: {e.Message}");
            }
        }

        private object? GetPropertyValue(Media media, string propertyName)
        {
            Type type = media.GetType();
            var property = type.GetProperty(propertyName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase);
            
            if (property != null)
            {
                return property.GetValue(media);
            }

            return null;
        }
    }
}