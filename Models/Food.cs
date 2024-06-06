using System.Dynamic;
namespace Project2.Models
{
    public class Food
    {
        //Properties

        public int FoodId { get; set; } //Primary Key
        public string? ItemName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool InStock { get; set; } //available or not
        public Purchase PurchaseId { get; set; }

        // //Constructors
        // public Food()
        // {
        //     ItemName = "";
        //     //Customer = new(); //because its an object and works bettr with ToString
        //     //Don't need this line if we add the ? to the property and below in ToString
        // }

        // public Food(int id, string itemName, double price, bool inStock, User? user)
        // {
        //     Id = id;
        //     ItemName = itemName;
        //     Price = price;
        //     InStock = inStock;
        // }


        // //Methods - Can ToString be moved to UI? Ryans movie example houses in model
        // public override string ToString()
        // {
        //     return "ID: " + Id
        //     + ", Item Name: " + ItemName
        //     + ", Price: " + Price
        //     + ", In Stock: " + InStock;
        // }
    }
}