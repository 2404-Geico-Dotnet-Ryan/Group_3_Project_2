using System.Dynamic;
using System.Xml;
namespace Project2.Models
{
    public class User //SQL table is called Logins due to User being a reserved word
    {
        public int UserId { get; set; } //Primary Key
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int PurchaseId { get; set; } //Foreign Key
        public Role Role { get; set; }//Foreign key that uses the Role look-up table
                                      //this avoids us hard coding roles
        public ICollection<Purchase> Purchases { get; set; }

        public User() { }

        public User(int userId, string userName, string password, int purchaseId)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            PurchaseId = purchaseId;
        }

        public override string ToString()
        {
            return $"{{UserId: {UserId},UserName: {UserName}, Password: {Password}, PurchaseId: {PurchaseId}}}"; ;
        }
    }
}