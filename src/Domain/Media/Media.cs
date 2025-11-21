using System;

namespace oop_workshop.src.Domain.Media
{
    public class Media
    {
        public string title { get; private set; }
        public double? rating { get; private set; }
        private int ratingCount = 0;
        
        public Media(string title)
        {
            this.title = title;
        }

        public void AddRating(int newRating)
        {
            if (newRating < 1 || newRating > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(newRating), "Rating must be between 1 and 5.");
            }

            // update average rating
            double total = (rating ?? 0.0) * ratingCount;
            ratingCount++;
            total += newRating;
            rating = total / ratingCount;
        }
    }
}