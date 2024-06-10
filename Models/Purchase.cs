using System.Dynamic;
using System.Xml;
namespace Project2.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; } //Primary Key
        public int UserId { get; set; } //foreign key, 
        public int FoodId { get; set; } //foreign?
        public int PurchaseQuantity { get; set; }
        public decimal Cost { get; set; }
        public DateTime PurchaseDate { get; set; }

        public User User { get; set; } //Foreign key connection



        public Purchase() { }

        public Purchase(int purchaseId, int userId, int foodId, int purchaseQuantity, decimal cost, DateTime purchaseDate)
        {
            PurchaseId = purchaseId;
            UserId = userId;
            FoodId = foodId;
            PurchaseQuantity = purchaseQuantity;
            Cost = cost;
            PurchaseDate = purchaseDate;
        }
        public override string ToString()
        {
            return $"{{PurchaseId: {PurchaseId},UserId: {UserId}, FoodId: {FoodId}, PurchaseQuantity: {PurchaseQuantity}, Cost: {Cost}, PurchaseDate: {PurchaseDate}}}";
        }

    }
}