using System.Dynamic;
using System.Xml;
namespace Project2.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; } //Primary Key
        public int Quantity { get; set; }
        public double Cost { get; set; }
        public long PurchaseDate { get; set; }

        public User UserId { get; set; } //Foreign key
        public Food FoodId { get; set; } //Foreign key
    }
}