class UserUtil
{
    public Dictionary<int, User> logins;

    public int idCounter = 1;

    // //Constructor to give us menu options to start:
    public UserUtil()
    {
        User user1 = new(idCounter++, "Amanda", "Password1", "Owner");
        User user2 = new(idCounter++, "Elizabeth", "Password2", "User");


        logins = []; //sets the dictionary to an empty collection, instead of at the top, 
        //moving it into the constructor
        logins.Add(user1.Id, user1);
        logins.Add(user2.Id, user2);
    }
}