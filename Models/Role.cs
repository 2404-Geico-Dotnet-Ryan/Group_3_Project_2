using System.Dynamic;
using System.Xml;
namespace Project2.Models
{
   public class Role
    {
        public int RoleId { get; set; } //Primary Key
        public string? UserType { get; set; }

        public User User { get; set; }
    }
}