
class UserService
{
    UserRepo? ur;
    public UserService(UserRepo? ur)
    {
        this.ur = ur;
    }

    //Register - taking in info and perform a login "registering"
    public User? Register(User u)
    {
        //Not allowing Owner to register (they should be added internally):
        if (u.Role != "user")
        {
            Console.WriteLine("Invalid role. Please contact System Coordinator to create your login.");
            return null;
        }
        //Not allowing duplicate User Names:
        //First step, get all users and compare what was entered to what exists
        List<User> allUsers = ur.GetAllUsers();
        foreach (User name in allUsers)
        {
            if (name.UserName == u.UserName)
            {
                Console.WriteLine("User Name already taken. Try again.");
                return null;
            }
        }
        //trivial service if we dont care about validation, or we use the code above with this:
        return ur.AddUser(u);
    }

    //Login
    public User? Login(string userName, string password)
    {
        List<User> allUsers = ur.GetAllUsers();
        foreach (User name in allUsers)
        {
            if (name.UserName == userName && name.Password == password)
            {
                return name;
            }
        }
        Console.WriteLine("Not a valid user name and/or password.");
        return null;
    }
}
