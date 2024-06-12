using System.Dynamic;
using System.Xml;
namespace Project2.Models
{
    public class Role
    {
        public int RoleId { get; set; } //Primary Key
        public string? UserType { get; set; } // Admin, Customer

        public ICollection<User> Users { get; set; }

        public Role() { }

        public Role(int roleId, string userType)
        {
            RoleId = roleId;
            UserType = userType;
        }

        public override string ToString()
        {
            return $"{{RoleId: {RoleId},UserType: {UserType}}}";
        }
    }
}