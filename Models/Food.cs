using System.Dynamic;
namespace Project2.Models
{
    public class Food
    {
        //Properties

        public int FoodId { get; set; } //Primary Key
        public string? ItemName { get; set; }
        public decimal Price { get; set; }
        public int FoodQuantity { get; set; }
        public bool InStock { get; set; } //available or not

        public ICollection<Purchase> Purchases { get; set; }

        public Food() { }

        public Food(int foodId, string itemName, decimal price, int foodQuantity, bool inStock)
        {
            FoodId = foodId;
            ItemName = itemName;
            Price = price;
            FoodQuantity = foodQuantity;
            InStock = inStock;
        }

        public override string ToString()
        {
            return $"{{FoodId: {FoodId},ItemName: {ItemName}, Price: {Price}, FoodQuantity: {FoodQuantity}, InStock: {InStock}}}";
        }
    }
}