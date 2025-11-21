namespace oop_workshop.src.Domain.User
{
    public abstract class User
    {
        public string Name { get; }
        public int Age { get; set; }
        public int SocialSecurityNumber { get; set; }

        public User(string name, int age, int ssn)
        {
            Name = name;
            Age = age;
            SocialSecurityNumber = ssn;
        }
    }
}