using System.Dynamic;
namespace Project2.Models
{
    public class Food //Object
    {
        //Properties

        public int FoodId { get; set; } //Primary Key
        public string? ItemName { get; set; }
        public decimal Price { get; set; }
        public int FoodQuantity { get; set; }
        public bool InStock { get; set; } //available or not

        public Purchase Purchase { get; set; }


        //Constructors:
        public Food() { } //Empty Constructor, "catch all" 

        //below is full argument/parameterized constructor:
        public Food(int foodId, string itemName, decimal price, int foodQuantity, bool inStock)
        {
            FoodId = foodId;
            ItemName = itemName;
            Price = price;
            FoodQuantity = foodQuantity;
            InStock = inStock;
        }

        public override string ToString() //gives us back all our fields for the object
        {
            return $"{{FoodId: {FoodId},ItemName: {ItemName}, Price: {Price}, FoodQuantity: {FoodQuantity}, InStock: {InStock}}}";
        }
    }
}