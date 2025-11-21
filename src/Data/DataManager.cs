using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using oop_workshop.src.Domain.Media;
using oop_workshop.src.Domain.User;

namespace oop_workshop.src.Data
{
    /// <summary>
    /// Handles saving and loading of media and user data to/from CSV files
    /// </summary>
    public static class DataManager
    {
        // Store data inside the repository `src/Persistance` folder as requested
        private static readonly string DataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "src", "Persistance");
        private static readonly string MediaFile = Path.Combine(DataDirectory, "media.csv");
        private static readonly string UsersFile = Path.Combine(DataDirectory, "users.csv");
        private static readonly string BorrowedFile = Path.Combine(DataDirectory, "borrowed.csv");

        static DataManager()
        {
            // Ensure data directory exists
            if (!Directory.Exists(DataDirectory))
            {
                Directory.CreateDirectory(DataDirectory);
            }
        }

        #region Media Persistence

        /// <summary>
        /// Saves all media items to CSV file
        /// </summary>
        public static void SaveMedia(List<Media> mediaCollection)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(MediaFile, false))
                {
                    // Write header
                    writer.WriteLine("MediaType,Title,Rating,RatingCount,Property1,Property2,Property3,Property4,Property5,Property6,Property7");

                    foreach (Media media in mediaCollection)
                    {
                        string line = SerializeMedia(media);
                        writer.WriteLine(line);
                    }
                }
                Console.WriteLine($"[INFO] Saved {mediaCollection.Count} media items.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to save media: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads all media items from CSV file
        /// </summary>
        public static List<Media> LoadMedia()
        {
            List<Media> mediaCollection = new List<Media>();

            if (!File.Exists(MediaFile))
            {
                Console.WriteLine("[INFO] No media file found. Starting with empty collection.");
                return mediaCollection;
            }

            try
            {
                string[] lines = File.ReadAllLines(MediaFile);
                
                // Skip header
                for (int i = 1; i < lines.Length; i++)
                {
                    Media? media = DeserializeMedia(lines[i]);
                    if (media != null)
                    {
                        mediaCollection.Add(media);
                    }
                }

                Console.WriteLine($"[INFO] Loaded {mediaCollection.Count} media items.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to load media: {ex.Message}");
            }

            return mediaCollection;
        }

        private static string SerializeMedia(Media media)
        {
            string mediaType = media.GetType().Name;
            string title = EscapeCsv(media.title);
            string rating = media.rating?.ToString(CultureInfo.InvariantCulture) ?? "";
            
            // Use reflection to get rating count
            var ratingCountField = typeof(Media).GetField("ratingCount", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            int ratingCount = ratingCountField != null ? (int)(ratingCountField.GetValue(media) ?? 0) : 0;

            string properties = "";

            switch (media)
            {
                case Movie movie:
                    properties = $"{EscapeCsv(movie.Director)},{EscapeCsv(string.Join("|", movie.Genres))},{movie.ReleaseYear},{EscapeCsv(movie.Language)},{movie.Duration},,";
                    break;
                case Song song:
                    properties = $"{EscapeCsv(song.Composer)},{EscapeCsv(song.Singer)},{EscapeCsv(song.Genre)},{EscapeCsv(song.FileType)},{song.Duration},{EscapeCsv(song.Language)},";
                    break;
                case EBook ebook:
                    properties = $"{EscapeCsv(ebook.Author)},{EscapeCsv(ebook.Language)},{ebook.NumberOfPages},{ebook.YearOfPublication},{EscapeCsv(ebook.ISBN)},,";
                    break;
                case Podcast podcast:
                    properties = $"{podcast.ReleaseYear},{EscapeCsv(string.Join("|", podcast.Hosts))},{EscapeCsv(string.Join("|", podcast.Guests))},{podcast.EpisodeNumber},{EscapeCsv(podcast.Language)},,";
                    break;
                case VideoGame game:
                    properties = $"{EscapeCsv(game.Genre)},{EscapeCsv(game.Publisher)},{game.ReleaseYear},{EscapeCsv(string.Join("|", game.SupportedPlatforms))},,,,";
                    break;
                case App app:
                    properties = $"{EscapeCsv(app.Version)},{EscapeCsv(app.Publisher)},{EscapeCsv(string.Join("|", app.SupportedPlatforms))},{app.FileSize.ToString(CultureInfo.InvariantCulture)},,,,";
                    break;
                case Image image:
                    properties = $"{EscapeCsv(image.Resolution)},{EscapeCsv(image.FileFormat)},{image.FileSize.ToString(CultureInfo.InvariantCulture)},{image.DateTaken.ToString("yyyy-MM-dd")},,,,";
                    break;
            }

            return $"{mediaType},{title},{rating},{ratingCount},{properties}";
        }

        private static Media? DeserializeMedia(string line)
        {
            try
            {
                string[] parts = ParseCsvLine(line);
                if (parts.Length < 4) return null;

                string mediaType = parts[0];
                string title = parts[1];
                double? rating = string.IsNullOrEmpty(parts[2]) ? null : double.Parse(parts[2], CultureInfo.InvariantCulture);
                int ratingCount = string.IsNullOrEmpty(parts[3]) ? 0 : int.Parse(parts[3]);

                Media? media = null;

                switch (mediaType)
                {
                    case "Movie":
                        if (parts.Length >= 9)
                        {
                            media = new Movie(
                                title,
                                parts[4],
                                parts[5].Split('|'),
                                int.Parse(parts[6]),
                                parts[7],
                                int.Parse(parts[8])
                            );
                        }
                        break;
                    case "Song":
                        if (parts.Length >= 10)
                        {
                            media = new Song(
                                title,
                                parts[4],
                                parts[5],
                                parts[6],
                                parts[7],
                                int.Parse(parts[8]),
                                parts[9]
                            );
                        }
                        break;
                    case "EBook":
                        if (parts.Length >= 9)
                        {
                            media = new EBook(
                                title,
                                parts[4],
                                parts[5],
                                int.Parse(parts[6]),
                                int.Parse(parts[7]),
                                parts[8]
                            );
                        }
                        break;
                    case "Podcast":
                        if (parts.Length >= 9)
                        {
                            media = new Podcast(
                                title,
                                int.Parse(parts[4]),
                                parts[5].Split('|'),
                                parts[6].Split('|'),
                                int.Parse(parts[7]),
                                parts[8]
                            );
                        }
                        break;
                    case "VideoGame":
                        if (parts.Length >= 8)
                        {
                            media = new VideoGame(
                                title,
                                parts[4],
                                parts[5],
                                int.Parse(parts[6]),
                                parts[7].Split('|')
                            );
                        }
                        break;
                    case "App":
                        if (parts.Length >= 8)
                        {
                            media = new App(
                                title,
                                parts[4],
                                parts[5],
                                parts[6].Split('|'),
                                double.Parse(parts[7], CultureInfo.InvariantCulture)
                            );
                        }
                        break;
                    case "Image":
                        if (parts.Length >= 8)
                        {
                            media = new Image(
                                title,
                                parts[4],
                                parts[5],
                                double.Parse(parts[6], CultureInfo.InvariantCulture),
                                DateTime.Parse(parts[7])
                            );
                        }
                        break;
                }

                // Restore rating and rating count using reflection
                if (media != null && rating.HasValue && ratingCount > 0)
                {
                    var ratingField = typeof(Media).GetProperty("rating", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
                    var ratingCountField = typeof(Media).GetField("ratingCount", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    
                    if (ratingField != null) ratingField.SetValue(media, rating);
                    if (ratingCountField != null) ratingCountField.SetValue(media, ratingCount);
                }

                return media;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to deserialize media line: {ex.Message}");
                return null;
            }
        }

        #endregion

        #region User Persistence

        /// <summary>
        /// Saves all users to CSV file
        /// </summary>
        public static void SaveUsers(List<User> userList)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(UsersFile, false))
                {
                    // Write header
                    writer.WriteLine("UserType,Name,Age,SSN");

                    foreach (User user in userList)
                    {
                        string userType = user.GetType().Name;
                        writer.WriteLine($"{userType},{EscapeCsv(user.Name)},{user.Age},{user.SocialSecurityNumber}");
                    }
                }
                Console.WriteLine($"[INFO] Saved {userList.Count} users.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to save users: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads all users from CSV file
        /// </summary>
        public static List<User> LoadUsers()
        {
            List<User> userList = new List<User>();

            if (!File.Exists(UsersFile))
            {
                Console.WriteLine("[INFO] No users file found. Starting with empty list.");
                return userList;
            }

            try
            {
                string[] lines = File.ReadAllLines(UsersFile);
                
                // Skip header
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = ParseCsvLine(lines[i]);
                    if (parts.Length < 4) continue;

                    string userType = parts[0];
                    string name = parts[1];
                    int age = int.Parse(parts[2]);
                    int ssn = int.Parse(parts[3]);

                    User? user = userType switch
                    {
                        "Borrower" => new Borrower(name, age, ssn),
                        "Employee" => new Employee(name, age, ssn),
                        "Admin" => new Admin(name, age, ssn),
                        _ => null
                    };

                    if (user != null)
                    {
                        userList.Add(user);
                    }
                }

                Console.WriteLine($"[INFO] Loaded {userList.Count} users.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to load users: {ex.Message}");
            }

            return userList;
        }

        #endregion

        #region Borrowed Media Persistence

        /// <summary>
        /// Saves borrowed media relationships to CSV file
        /// </summary>
        public static void SaveBorrowedMedia(List<User> userList, List<Media> mediaCollection)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(BorrowedFile, false))
                {
                    // Write header
                    writer.WriteLine("BorrowerSSN,MediaTitle");

                    foreach (User user in userList)
                    {
                        if (user is Borrower borrower)
                        {
                            foreach (Media media in borrower.borrowed_media)
                            {
                                writer.WriteLine($"{borrower.SocialSecurityNumber},{EscapeCsv(media.title)}");
                            }
                        }
                    }
                }
                Console.WriteLine("[INFO] Saved borrowed media relationships.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to save borrowed media: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads borrowed media relationships from CSV file
        /// </summary>
        public static void LoadBorrowedMedia(List<User> userList, List<Media> mediaCollection)
        {
            if (!File.Exists(BorrowedFile))
            {
                Console.WriteLine("[INFO] No borrowed media file found.");
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(BorrowedFile);
                
                // Skip header
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] parts = ParseCsvLine(lines[i]);
                    if (parts.Length < 2) continue;

                    int borrowerSSN = int.Parse(parts[0]);
                    string mediaTitle = parts[1];

                    // Find borrower
                    Borrower? borrower = userList.OfType<Borrower>().FirstOrDefault(b => b.SocialSecurityNumber == borrowerSSN);
                    if (borrower == null) continue;

                    // Find media
                    Media? media = mediaCollection.FirstOrDefault(m => m.title == mediaTitle);
                    if (media == null) continue;

                    // Add to borrowed list using reflection to bypass the private setter
                    if (!borrower.borrowed_media.Contains(media))
                    {
                        borrower.borrowed_media.Add(media);
                    }
                }

                Console.WriteLine("[INFO] Loaded borrowed media relationships.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to load borrowed media: {ex.Message}");
            }
        }

        #endregion

        #region Helper Methods

        private static string EscapeCsv(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }

            return value;
        }

        private static string[] ParseCsvLine(string line)
        {
            List<string> result = new List<string>();
            bool inQuotes = false;
            string currentValue = "";

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    if (inQuotes && i + 1 < line.Length && line[i + 1] == '"')
                    {
                        // Escaped quote
                        currentValue += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = !inQuotes;
                    }
                }
                else if (c == ',' && !inQuotes)
                {
                    result.Add(currentValue);
                    currentValue = "";
                }
                else
                {
                    currentValue += c;
                }
            }

            result.Add(currentValue);
            return result.ToArray();
        }

        #endregion
    }
}
