using System.Security.Cryptography.X509Certificates;
using oop_workshop.src.Domain.Media;

public class Employee : User
{
    public Employee(string name, int age, int ssn) : base(name, age, ssn)
    {
    }

    public void AddMedia(List<Media> mediaList, Media media)
    {
        mediaList.Add(media);
    }
            
    public void RemoveMedia(List<Media> mediaList, Media media)
    {
        mediaList.Remove(media);
    }
}