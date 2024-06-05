using System.Dynamic;

class Food
{
    //Properties

    public int Id { get; set; }
    public string ItemName { get; set; }
    public double Price { get; set; }
    public bool InStock { get; set; }
    //User model added:
    //Who checks out the food:
    public User? User { get; set; }



    //Constructors
    public Food()
    {
        ItemName = "";
        //Customer = new(); //because its an object and works bettr with ToString
        //Don't need this line if we add the ? to the property and below in ToString
    }

    public Food(int id, string itemName, double price, bool inStock, User? user)
    {
        Id = id;
        ItemName = itemName;
        Price = price;
        InStock = inStock;
        User = user;

    }


    //Methods - Can ToString be moved to UI? Ryans movie example houses in model
    public override string ToString()
    {
        return "ID: " + Id
        + ", Item Name: " + ItemName
        + ", Price: " + Price
        + ", In Stock: " + InStock
        + ", Customer: " + User?.ToString(); //This will include User object and become
        //a whole other object. Or, you can do Customer.Id if you want to simplify
    //Null cannot call the ToString object
    }




}