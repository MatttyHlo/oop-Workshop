using System;
using System.Collections.Generic;
using System.Reflection;

namespace oop_workshop.src.Domain.Media
{
    /// <summary>
    /// Generic comparer that uses reflection to compare Media objects by a specified property
    /// Automatically uses string comparison for string properties and numeric comparison for number properties
    /// </summary>
    public class GenericMediaComparer : IComparer<Media>
    {
        private readonly string _propertyName;
        private readonly bool _descending;

        public GenericMediaComparer(string propertyName, bool descending = false)
        {
            _propertyName = propertyName;
            _descending = descending;
        }

        public int Compare(Media? x, Media? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            object? valueX = GetPropertyValue(x, _propertyName);
            object? valueY = GetPropertyValue(y, _propertyName);

            // Handle null values - items without the property go to the end
            if (valueX == null && valueY == null) return 0;
            if (valueX == null) return 1;
            if (valueY == null) return -1;

            int result = 0;

            // Use built-in string comparer for strings
            if (valueX is string strX && valueY is string strY)
            {
                result = string.Compare(strX, strY, StringComparison.OrdinalIgnoreCase);
            }
            // Use built-in numeric comparer for numbers
            else if (valueX is IComparable comparableX)
            {
                result = comparableX.CompareTo(valueY);
            }

            // Reverse order if descending
            return _descending ? -result : result;
        }

        private object? GetPropertyValue(Media media, string propertyName)
        {
            // Try to get property from the media object or its derived type
            Type type = media.GetType();
            PropertyInfo? property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            
            if (property != null)
            {
                return property.GetValue(media);
            }

            return null;
        }
    }

    /// <summary>
    /// Special comparer for rating that handles nullable doubles
    /// </summary>
    public class RatingComparer : IComparer<Media>
    {
        public int Compare(Media? x, Media? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            // Handle null ratings - items with no rating go to the end
            if (!x.rating.HasValue && !y.rating.HasValue) return 0;
            if (!x.rating.HasValue) return 1;
            if (!y.rating.HasValue) return -1;

            // Sort descending (highest rating first)
            return y.rating.Value.CompareTo(x.rating.Value);
        }
    }
}
