//implement asking for role
class Program
{
    static void Main(string[] args)
    {
        List<Media> collection = new List<Media>();
        Employee employee1 = new Employee("Harry", 69, 0202020202);
        employee1.AddMedia(collection ,new Movie("Harry Potter", "Some Guy", [action, comedy], 2001, "English", 120));
        Borrower person1 = new Borrower("Jack", 13, 0101010101);
        person1.ListItems(collection, "Movie"); 


    }
}