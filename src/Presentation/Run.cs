using oop_workshop.src.Domain.Media;
using oop_workshop.src.Domain.Interfaces;

namespace oop_workshop.src.Presentation
{
    public static class Run
    {
        private static List<Media> mediaCollection = new List<Media>();
        private static List<User> userList = new List<User>();

        public static void Initialize()
        {
            // Initialize sample media
            mediaCollection.Add(new Movie("The Matrix", "Wachowski Brothers", new string[] { "Action", "Sci-Fi" }, 1999, "English", 136));
            mediaCollection.Add(new Movie("Inception", "Christopher Nolan", new string[] { "Action", "Thriller" }, 2010, "English", 148));
            mediaCollection.Add(new Movie("Interstellar", "Christopher Nolan", new string[] { "Sci-Fi", "Drama" }, 2014, "English", 169));
            
            mediaCollection.Add(new Song("Bohemian Rhapsody", "Freddie Mercury", "Queen", "Rock", "MP3", 354, "English"));
            mediaCollection.Add(new Song("Imagine", "John Lennon", "John Lennon", "Pop", "FLAC", 183, "English"));
            
            mediaCollection.Add(new EBook("1984", "George Orwell", "English", 328, 1949, "978-0451524935"));
            mediaCollection.Add(new EBook("Clean Code", "Robert C. Martin", "English", 464, 2008, "978-0132350884"));
            
            mediaCollection.Add(new Podcast("Tech Talk Daily", 2023, new string[] { "John Doe", "Jane Smith" }, new string[] { "Elon Musk" }, 42, "English"));
            
            mediaCollection.Add(new VideoGame("The Witcher 3", "RPG", "CD Projekt Red", 2015, new string[] { "PC", "PlayStation", "Xbox" }));
            
            mediaCollection.Add(new App("Spotify", "8.8.0", "Spotify AB", new string[] { "iOS", "Android", "Windows" }, 95.5));
            
            mediaCollection.Add(new Image("Sunset Beach", "4K", "JPG", 8.5, new DateTime(2023, 6, 15)));

            // Initialize sample users
            userList.Add(new Borrower("Alice Johnson", 25, 123456789));
            userList.Add(new Borrower("Bob Smith", 30, 987654321));
            userList.Add(new Employee("Charlie Brown", 35, 111222333));
            userList.Add(new Admin("Diana Prince", 40, 444555666));
        }

        public static void Start()
        {
            Console.Clear();
            Console.WriteLine("=== LIBRARY MANAGEMENT SYSTEM ===");
            Console.WriteLine();
            Console.WriteLine("Select your role:");
            Console.WriteLine("[1] Borrower");
            Console.WriteLine("[2] Employee");
            Console.WriteLine("[3] Admin");
            Console.Write("\nChoice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    Borrower borrower = new Borrower("Guest User", 25, 999999999);
                    ShowBorrowerMenu(borrower);
                    break;
                case "2":
                    Employee employee = new Employee("Guest Employee", 30, 888888888);
                    ShowEmployeeMenu(employee);
                    break;
                case "3":
                    Admin admin = new Admin("Guest Admin", 35, 777777777);
                    ShowAdminMenu(admin);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting...");
                    break;
            }
        }

        private static void ShowBorrowerMenu(Borrower borrower)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== BORROWER MENU ===");
                Console.WriteLine("[1] List items by type");
                Console.WriteLine("[2] View item details");
                Console.WriteLine("[3] Rate an item");
                Console.WriteLine("[4] Perform media action");
                Console.WriteLine("[5] Exit");
                Console.Write("\nChoice: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        ListItemsByType(borrower);
                        break;
                    case "2":
                        ViewItemDetails(borrower);
                        break;
                    case "3":
                        RateItem();
                        break;
                    case "4":
                        PerformMediaAction();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        PauseScreen();
                        break;
                }
            }
        }

        private static void ShowEmployeeMenu(Employee employee)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== EMPLOYEE MENU ===");
                Console.WriteLine("[1] Add media item");
                Console.WriteLine("[2] Remove media item");
                Console.WriteLine("[3] View all media");
                Console.WriteLine("[4] Exit");
                Console.Write("\nChoice: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        AddMediaItem(employee);
                        break;
                    case "2":
                        RemoveMediaItem(employee);
                        break;
                    case "3":
                        ViewAllMedia();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        PauseScreen();
                        break;
                }
            }
        }

        private static void ShowAdminMenu(Admin admin)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ADMIN MENU ===");
                Console.WriteLine("[1] Manage Media");
                Console.WriteLine("[2] Manage Users");
                Console.WriteLine("[3] Exit");
                Console.Write("\nChoice: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        ManageMediaSubmenu(admin);
                        break;
                    case "2":
                        ManageUsersSubmenu(admin);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        PauseScreen();
                        break;
                }
            }
        }

        private static void ManageMediaSubmenu(Admin admin)
        {
            Console.Clear();
            Console.WriteLine("=== MANAGE MEDIA ===");
            Console.WriteLine("[1] Add media");
            Console.WriteLine("[2] Remove media");
            Console.WriteLine("[3] View all media");
            Console.Write("\nChoice: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddMediaItem(admin);
                    break;
                case "2":
                    RemoveMediaItem(admin);
                    break;
                case "3":
                    ViewAllMedia();
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    PauseScreen();
                    break;
            }
        }

        private static void ManageUsersSubmenu(Admin admin)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== MANAGE USERS ===");
                Console.WriteLine("[1] View all users");
                Console.WriteLine("[2] Create user");
                Console.WriteLine("[3] Delete user");
                Console.WriteLine("[4] Update user");
                Console.WriteLine("[5] Back");
                Console.Write("\nChoice: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        admin.ViewUserInfo(userList);
                        PauseScreen();
                        break;
                    case "2":
                        CreateUser(admin);
                        break;
                    case "3":
                        DeleteUser(admin);
                        break;
                    case "4":
                        UpdateUser(admin);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        PauseScreen();
                        break;
                }
            }
        }

        // === BORROWER METHODS ===

        private static void ListItemsByType(Borrower borrower)
        {
            Console.Clear();
            Console.WriteLine("=== LIST ITEMS BY TYPE ===");
            Console.WriteLine("Available types: Movie, Song, EBook, Podcast, VideoGame, App, Image");
            Console.Write("\nEnter type: ");
            string type = Console.ReadLine() ?? "";

            Console.WriteLine();
            borrower.ListItems(mediaCollection, type);
            PauseScreen();
        }

        private static void ViewItemDetails(Borrower borrower)
        {
            Console.Clear();
            Console.WriteLine("=== VIEW ITEM DETAILS ===");
            Console.Write("Enter item title: ");
            string title = Console.ReadLine() ?? "";

            Console.WriteLine();
            borrower.ViewDetails(title, mediaCollection);
            PauseScreen();
        }

        private static void RateItem()
        {
            Console.Clear();
            Console.WriteLine("=== RATE ITEM ===");
            Console.Write("Enter item title: ");
            string title = Console.ReadLine() ?? "";

            Media? media = mediaCollection.FirstOrDefault(m => m.title.Equals(title, StringComparison.OrdinalIgnoreCase));
            
            if (media == null)
            {
                Console.WriteLine("Item not found.");
                PauseScreen();
                return;
            }

            Console.Write("Enter rating (1-5): ");
            if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
            {
                if (media is IRatable ratable)
                {
                    ratable.Rate(rating);
                }
                else
                {
                    Console.WriteLine("This item cannot be rated.");
                }
            }
            else
            {
                Console.WriteLine("Invalid rating. Must be between 1 and 5.");
            }
            
            PauseScreen();
        }

        private static void PerformMediaAction()
        {
            Console.Clear();
            Console.WriteLine("=== PERFORM MEDIA ACTION ===");
            Console.Write("Enter item title: ");
            string title = Console.ReadLine() ?? "";

            Media? media = mediaCollection.FirstOrDefault(m => m.title.Equals(title, StringComparison.OrdinalIgnoreCase));
            
            if (media == null)
            {
                Console.WriteLine("Item not found.");
                PauseScreen();
                return;
            }

            Console.WriteLine($"\nSelected: {media.title}");
            Console.WriteLine("\nAvailable actions:");

            if (media is Movie movie)
            {
                Console.WriteLine("[1] Watch");
                Console.WriteLine("[2] Download");
                Console.Write("\nChoice: ");
                string choice = Console.ReadLine() ?? "";
                
                if (choice == "1") movie.Watch();
                else if (choice == "2") movie.Download("http://example.com/movie");
                else Console.WriteLine("Invalid option.");
            }
            else if (media is Song song)
            {
                Console.WriteLine("[1] Play");
                Console.WriteLine("[2] Pause");
                Console.WriteLine("[3] Stop");
                Console.WriteLine("[4] Download");
                Console.Write("\nChoice: ");
                string choice = Console.ReadLine() ?? "";
                
                switch (choice)
                {
                    case "1": song.Play(); break;
                    case "2": song.Pause(); break;
                    case "3": song.Stop(); break;
                    case "4": song.Download("http://example.com/song"); break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
            else if (media is EBook ebook)
            {
                Console.WriteLine("[1] Read");
                Console.WriteLine("[2] View");
                Console.WriteLine("[3] Download");
                Console.Write("\nChoice: ");
                string choice = Console.ReadLine() ?? "";
                
                if (choice == "1") ebook.Read();
                else if (choice == "2") ebook.View();
                else if (choice == "3") ebook.Download("http://example.com/ebook");
                else Console.WriteLine("Invalid option.");
            }
            else if (media is Podcast podcast)
            {
                Console.WriteLine("[1] Listen");
                Console.WriteLine("[2] Complete");
                Console.WriteLine("[3] Download");
                Console.Write("\nChoice: ");
                string choice = Console.ReadLine() ?? "";
                
                if (choice == "1") podcast.Listen();
                else if (choice == "2") podcast.Complete();
                else if (choice == "3") podcast.Download("http://example.com/podcast");
                else Console.WriteLine("Invalid option.");
            }
            else if (media is VideoGame game)
            {
                Console.WriteLine("[1] Play");
                Console.WriteLine("[2] Pause");
                Console.WriteLine("[3] Stop");
                Console.WriteLine("[4] Complete");
                Console.WriteLine("[5] Download");
                Console.Write("\nChoice: ");
                string choice = Console.ReadLine() ?? "";
                
                switch (choice)
                {
                    case "1": game.Play(); break;
                    case "2": game.Pause(); break;
                    case "3": game.Stop(); break;
                    case "4": game.Complete(); break;
                    case "5": game.Download("http://example.com/game"); break;
                    default: Console.WriteLine("Invalid option."); break;
                }
            }
            else if (media is App app)
            {
                Console.WriteLine("[1] Execute");
                Console.WriteLine("[2] Download");
                Console.Write("\nChoice: ");
                string choice = Console.ReadLine() ?? "";
                
                if (choice == "1") app.Execute();
                else if (choice == "2") app.Download("http://example.com/app");
                else Console.WriteLine("Invalid option.");
            }
            else if (media is Image image)
            {
                Console.WriteLine("[1] Display");
                Console.WriteLine("[2] Download");
                Console.Write("\nChoice: ");
                string choice = Console.ReadLine() ?? "";
                
                if (choice == "1") image.Display();
                else if (choice == "2") image.Download("http://example.com/image");
                else Console.WriteLine("Invalid option.");
            }

            PauseScreen();
        }

        // === EMPLOYEE METHODS ===

        private static void AddMediaItem(Employee employee)
        {
            Console.Clear();
            Console.WriteLine("=== ADD MEDIA ITEM ===");
            Console.WriteLine("[1] Movie");
            Console.WriteLine("[2] Song");
            Console.WriteLine("[3] EBook");
            Console.WriteLine("[4] Podcast");
            Console.WriteLine("[5] VideoGame");
            Console.WriteLine("[6] App");
            Console.WriteLine("[7] Image");
            Console.Write("\nChoice: ");

            string choice = Console.ReadLine() ?? "";

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Title: ");
                        string title = Console.ReadLine() ?? "";
                        Console.Write("Director: ");
                        string director = Console.ReadLine() ?? "";
                        Console.Write("Genres (comma-separated): ");
                        string[] genres = (Console.ReadLine() ?? "").Split(',').Select(g => g.Trim()).ToArray();
                        Console.Write("Release Year: ");
                        int year = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Language: ");
                        string language = Console.ReadLine() ?? "";
                        Console.Write("Duration (minutes): ");
                        int duration = int.Parse(Console.ReadLine() ?? "0");
                        
                        employee.AddMedia(mediaCollection, new Movie(title, director, genres, year, language, duration));
                        Console.WriteLine("\nMovie added successfully!");
                        break;

                    case "2":
                        Console.Write("Title: ");
                        string songTitle = Console.ReadLine() ?? "";
                        Console.Write("Composer: ");
                        string composer = Console.ReadLine() ?? "";
                        Console.Write("Singer: ");
                        string singer = Console.ReadLine() ?? "";
                        Console.Write("Genre: ");
                        string genre = Console.ReadLine() ?? "";
                        Console.Write("File Type: ");
                        string fileType = Console.ReadLine() ?? "";
                        Console.Write("Duration (seconds): ");
                        int songDuration = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Language: ");
                        string songLanguage = Console.ReadLine() ?? "";
                        
                        employee.AddMedia(mediaCollection, new Song(songTitle, composer, singer, genre, fileType, songDuration, songLanguage));
                        Console.WriteLine("\nSong added successfully!");
                        break;

                    case "3":
                        Console.Write("Title: ");
                        string ebookTitle = Console.ReadLine() ?? "";
                        Console.Write("Author: ");
                        string author = Console.ReadLine() ?? "";
                        Console.Write("Language: ");
                        string ebookLanguage = Console.ReadLine() ?? "";
                        Console.Write("Number of Pages: ");
                        int pages = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Year of Publication: ");
                        int pubYear = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("ISBN: ");
                        string isbn = Console.ReadLine() ?? "";
                        
                        employee.AddMedia(mediaCollection, new EBook(ebookTitle, author, ebookLanguage, pages, pubYear, isbn));
                        Console.WriteLine("\nEBook added successfully!");
                        break;

                    case "4":
                        Console.Write("Title: ");
                        string podcastTitle = Console.ReadLine() ?? "";
                        Console.Write("Release Year: ");
                        int podcastYear = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Hosts (comma-separated): ");
                        string[] hosts = (Console.ReadLine() ?? "").Split(',').Select(h => h.Trim()).ToArray();
                        Console.Write("Guests (comma-separated): ");
                        string[] guests = (Console.ReadLine() ?? "").Split(',').Select(g => g.Trim()).ToArray();
                        Console.Write("Episode Number: ");
                        int episodeNumber = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Language: ");
                        string podcastLanguage = Console.ReadLine() ?? "";
                        
                        employee.AddMedia(mediaCollection, new Podcast(podcastTitle, podcastYear, hosts, guests, episodeNumber, podcastLanguage));
                        Console.WriteLine("\nPodcast added successfully!");
                        break;

                    case "5":
                        Console.Write("Title: ");
                        string gameTitle = Console.ReadLine() ?? "";
                        Console.Write("Genre: ");
                        string gameGenre = Console.ReadLine() ?? "";
                        Console.Write("Publisher: ");
                        string publisher = Console.ReadLine() ?? "";
                        Console.Write("Release Year: ");
                        int gameYear = int.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Supported Platforms (comma-separated): ");
                        string[] platforms = (Console.ReadLine() ?? "").Split(',').Select(p => p.Trim()).ToArray();
                        
                        employee.AddMedia(mediaCollection, new VideoGame(gameTitle, gameGenre, publisher, gameYear, platforms));
                        Console.WriteLine("\nVideo Game added successfully!");
                        break;

                    case "6":
                        Console.Write("Title: ");
                        string appTitle = Console.ReadLine() ?? "";
                        Console.Write("Version: ");
                        string version = Console.ReadLine() ?? "";
                        Console.Write("Publisher: ");
                        string appPublisher = Console.ReadLine() ?? "";
                        Console.Write("Supported Platforms (comma-separated): ");
                        string[] appPlatforms = (Console.ReadLine() ?? "").Split(',').Select(p => p.Trim()).ToArray();
                        Console.Write("File Size (MB): ");
                        double fileSize = double.Parse(Console.ReadLine() ?? "0");
                        
                        employee.AddMedia(mediaCollection, new App(appTitle, version, appPublisher, appPlatforms, fileSize));
                        Console.WriteLine("\nApp added successfully!");
                        break;

                    case "7":
                        Console.Write("Title: ");
                        string imageTitle = Console.ReadLine() ?? "";
                        Console.Write("Resolution: ");
                        string resolution = Console.ReadLine() ?? "";
                        Console.Write("File Format: ");
                        string format = Console.ReadLine() ?? "";
                        Console.Write("File Size (MB): ");
                        double imageSize = double.Parse(Console.ReadLine() ?? "0");
                        Console.Write("Date Taken (yyyy-MM-dd): ");
                        DateTime dateTaken = DateTime.Parse(Console.ReadLine() ?? DateTime.Now.ToString());
                        
                        employee.AddMedia(mediaCollection, new Image(imageTitle, resolution, format, imageSize, dateTaken));
                        Console.WriteLine("\nImage added successfully!");
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError adding media: {ex.Message}");
            }

            PauseScreen();
        }

        private static void RemoveMediaItem(Employee employee)
        {
            Console.Clear();
            Console.WriteLine("=== REMOVE MEDIA ITEM ===");
            Console.Write("Enter item title to remove: ");
            string title = Console.ReadLine() ?? "";

            Media? media = mediaCollection.FirstOrDefault(m => m.title.Equals(title, StringComparison.OrdinalIgnoreCase));
            
            if (media != null)
            {
                employee.RemoveMedia(mediaCollection, media);
                Console.WriteLine($"\n'{title}' removed successfully!");
            }
            else
            {
                Console.WriteLine("Item not found.");
            }

            PauseScreen();
        }

        private static void ViewAllMedia()
        {
            Console.Clear();
            Console.WriteLine("=== ALL MEDIA ITEMS ===\n");
            
            if (mediaCollection.Count == 0)
            {
                Console.WriteLine("No media items in collection.");
            }
            else
            {
                foreach (var media in mediaCollection)
                {
                    Console.WriteLine($"- {media.title} ({media.GetType().Name})");
                }
            }

            PauseScreen();
        }

        // === ADMIN USER MANAGEMENT METHODS ===

        private static void CreateUser(Admin admin)
        {
            Console.Clear();
            Console.WriteLine("=== CREATE USER ===");
            Console.WriteLine("[1] Borrower");
            Console.WriteLine("[2] Employee");
            Console.WriteLine("[3] Admin");
            Console.Write("\nChoice: ");

            string choice = Console.ReadLine() ?? "";

            try
            {
                Console.Write("Name: ");
                string name = Console.ReadLine() ?? "";
                Console.Write("Age: ");
                int age = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("SSN: ");
                int ssn = int.Parse(Console.ReadLine() ?? "0");

                User newUser = choice switch
                {
                    "1" => new Borrower(name, age, ssn),
                    "2" => new Employee(name, age, ssn),
                    "3" => new Admin(name, age, ssn),
                    _ => throw new Exception("Invalid user type")
                };

                admin.CreateUser(userList, newUser);
                Console.WriteLine("\nUser created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError creating user: {ex.Message}");
            }

            PauseScreen();
        }

        private static void DeleteUser(Admin admin)
        {
            Console.Clear();
            Console.WriteLine("=== DELETE USER ===");
            Console.Write("Enter user name: ");
            string name = Console.ReadLine() ?? "";

            User? user = userList.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            
            if (user != null)
            {
                admin.DeleteUser(userList, user);
                Console.WriteLine($"\nUser '{name}' deleted successfully!");
            }
            else
            {
                Console.WriteLine("User not found.");
            }

            PauseScreen();
        }

        private static void UpdateUser(Admin admin)
        {
            Console.Clear();
            Console.WriteLine("=== UPDATE USER ===");
            Console.Write("Enter user name to update: ");
            string name = Console.ReadLine() ?? "";

            User? oldUser = userList.FirstOrDefault(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            
            if (oldUser == null)
            {
                Console.WriteLine("User not found.");
                PauseScreen();
                return;
            }

            try
            {
                Console.WriteLine($"\nCurrent user: {oldUser.Name} (Age: {oldUser.Age}, SSN: {oldUser.SocialSecurityNumber})");
                Console.WriteLine("\nEnter new details:");
                
                Console.Write("Name: ");
                string newName = Console.ReadLine() ?? "";
                Console.Write("Age: ");
                int newAge = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("SSN: ");
                int newSsn = int.Parse(Console.ReadLine() ?? "0");

                User newUser = oldUser switch
                {
                    Borrower => new Borrower(newName, newAge, newSsn),
                    Admin => new Admin(newName, newAge, newSsn),
                    Employee => new Employee(newName, newAge, newSsn),
                    _ => throw new Exception("Unknown user type")
                };

                admin.UpdateUser(userList, oldUser, newUser);
                Console.WriteLine("\nUser updated successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError updating user: {ex.Message}");
            }

            PauseScreen();
        }

        // === HELPER METHODS ===

        private static void PauseScreen()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
