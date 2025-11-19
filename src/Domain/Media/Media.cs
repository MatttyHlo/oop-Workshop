namespace oop_workshop.src.Domain.Media
{
    public class Media
    {
        public string title { get; private set; }
        
        public Media(string title)
        {
            this.title = title;
        }
    }
}