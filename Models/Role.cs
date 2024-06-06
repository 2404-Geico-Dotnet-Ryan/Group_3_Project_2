using System.Dynamic;
using System.Xml;
namespace Project2.Models
{
    public class Role
    {
        public int RoleId { get; set; } //Primary Key
        public string? UserType { get; set; } // Admin, Customer
        public int UserId { get; set; } //Foreign key

        public User User { get; set; }

        public Role() { }

        public Role(int roleId, string userType, int userId)
        {
            RoleId = roleId;
            UserType = userType;
            UserId = userId;
        }

        public override string ToString()
        {
            return $"{{RoleId: {RoleId},UserType: {UserType}, UserId: {UserId}}}"; ;
        }
    }
}