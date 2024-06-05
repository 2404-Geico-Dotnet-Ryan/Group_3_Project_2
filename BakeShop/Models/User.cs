using System.Dynamic;
using System.Xml;

class User //SQL table is called Logins due to User being a reserved word
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }


    public User()
    {
        Role = "";
        UserName = "";
        Password = "";
    }
    public User(int id, string userName, string password, string role)
    {
        Id = id;
        UserName = userName;
        Password = password;
        Role = role;
    }


    public override string ToString() //allows for single quotations
    {
        return "ID: " + Id
        + ", User Name: " + UserName
        + ", Password: " + Password
        + ", Role: " + Role;

    }


    //If user is Owner --> add, edit, delete bake goods. Will that functionality live here?

    //If user is customer --> Order items, review last order. Will that functionality live here?
}