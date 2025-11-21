using System;
using System.Linq;
using System.Collections.Generic;

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

        /// <summary>
        /// Organizes and displays a list of media items based on string criteria
        /// Uses reflection to automatically detect property types and apply appropriate comparers
        /// Supported criteria: title, rating, director, author, composer, singer, duration, 
        /// ReleaseYear, YearOfPublication, etc. - any public property on Media or derived types
        /// </summary>
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

            // Special handling for rating (nullable double, highest first)
            if (criteriaLower == "rating")
            {
                comparer = new RatingComparer();
                sortDescription = "Rating (Highest First)";
            }
            // For year-based sorting, use descending order (most recent first)
            else if (criteriaLower == "year" || criteriaLower == "releaseyear" || criteriaLower == "yearofpublication")
            {
                // Try ReleaseYear first, then YearOfPublication
                comparer = new GenericMediaComparer("ReleaseYear", descending: true);
                sortDescription = "Year (Most Recent First)";
            }
            // For all other criteria, use ascending order with automatic type detection
            else
            {
                comparer = new GenericMediaComparer(criteria, descending: false);
                sortDescription = $"{criteria} (A-Z / Ascending)";
            }

            try
            {
                List<Media> sortedList = new List<Media>(items);
                sortedList.Sort(comparer);

                Console.WriteLine($"\n--- Media List Organized by {sortDescription} ---");
                foreach (Media item in sortedList)
                {
                    string ratingStr = item.rating.HasValue ? $"{item.rating.Value:F1}" : "N/A";
                    Console.WriteLine($"[{item.GetType().Name}] {item.title} (Rating: {ratingStr})");
                }
                Console.WriteLine($"--- Total: {sortedList.Count} items ---\n");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error organizing media list: {e.Message}");
            }
        }

        /// <summary>
        /// Organizes borrowed media based on string criteria
        /// </summary>
    }
    
}