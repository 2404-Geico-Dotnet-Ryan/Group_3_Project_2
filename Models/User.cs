using System.Dynamic;
using System.Xml;
namespace Project2.Models
{
    public class User //SQL table is called Logins due to User being a reserved word
    {
        public int UserId { get; set; } //Primary Key
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public Role RoleId { get; set; }//Foreign key that uses the Role look-up table
                                        //this avoids us hard coding roles
        public Purchase PurchaseId { get; set; }
    }
}