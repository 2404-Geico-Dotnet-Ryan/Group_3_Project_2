using System.Dynamic;
using System.Xml;
namespace Project2.Models
{
    public class User //SQL table is called Logins due to User being a reserved word
    {
        internal object UserRoleId;

        public int UserId { get; set; } //Primary Key
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
        
        public Role Role { get; set; }//Foreign key that uses the Role look-up table
        //                               //this avoids us hard coding roles
        public ICollection<Purchase> Purchases { get; set; }

        public User() { }

        public User(int userId, string userName, string password, int roleId)
        {
            UserId = userId;
            UserName = userName;
            Password = password;
            RoleId = roleId;
        }

        public override string ToString()
        {
            return $"{{UserId: {UserId},UserName: {UserName}, Password: {Password}, RoleId: {RoleId}}}";
        }
    }
}