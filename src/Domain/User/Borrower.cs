public class Borrower : User
{
    public Borrower(string name, int age, int ssn) : base(name, age, ssn)
    {
    }

    public void ListItems(Media[] items, string type) {
        foreach (Media item in items)
        {
            if (item.GetType().Name == type)
            {
                item.DisplayInfo();
            }
        }

    }

    public void ViewDetails
}