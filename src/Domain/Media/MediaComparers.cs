using System.Reflection;

namespace oop_workshop.src.Domain.Media
{
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

            if (valueX == null && valueY == null) return 0;
            if (valueX == null) return 1;
            if (valueY == null) return -1;

            int result = 0;

            if (valueX is string strX && valueY is string strY)
            {
                result = string.Compare(strX, strY, StringComparison.OrdinalIgnoreCase);
            }
            else if (valueX is IComparable comparableX)
            {
                result = comparableX.CompareTo(valueY);
            }

            return _descending ? -result : result;
        }

        private object? GetPropertyValue(Media media, string propertyName)
        {
            Type type = media.GetType();
            PropertyInfo? property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            
            if (property != null)
            {
                return property.GetValue(media);
            }

            return null;
        }
    }

    public class RatingComparer : IComparer<Media>
    {
        public int Compare(Media? x, Media? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            if (!x.rating.HasValue && !y.rating.HasValue) return 0;
            if (!x.rating.HasValue) return 1;
            if (!y.rating.HasValue) return -1;

            return y.rating.Value.CompareTo(x.rating.Value);
        }
    }
}
