public class Admin : Employee
{
    public Admin(string name, int age, int ssn) : base(name, age, ssn)
    {
    }

    public void ViewUserInfo(List<User> userList)
    {
        foreach (var user in userList)
        {
            Console.WriteLine(user.Name);
            Console.WriteLine(user.Age);
            Console.WriteLine(user.SocialSecurityNumber);
        }
    }
    public void CreateUser(List<User> userList, User user)
    {
        userList.Add(user);
    }
    public void DeleteUser(List<User> userList, User user)
    {
        userList.Remove(user);
    }
    public void UpdateUser(List<User> userList, User oldUser, User newUser)
    {
        int index = userList.IndexOf(oldUser);
        if (index != -1)
        {
            userList[index] = newUser;
        }
    }
}