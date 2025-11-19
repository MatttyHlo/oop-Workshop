interface IRatable
{
    void Rate(int rating)
    {
        Console.WriteLine($"Rated with {rating} stars.");
    }
}