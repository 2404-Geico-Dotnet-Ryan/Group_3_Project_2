using Project2.DTOs;
using Project2.Models;

namespace Project2.Services
{
    public interface IRoleService
    {
        // Method to get a list of all users
        IEnumerable<RoleDTO> GetAllRoles();

        // Method to get a specific user by their ID
        RoleDTO GetRoleById(int RoleId);

        // Method to create a new user based on the provided RoleDTO
        Role CreateRole(RoleDTO RoleDto);

        // Method to update an existing user based on their ID and the provided updated RoleDTO
        void UpdatedRole(int RoleId, RoleDTO UpdatedRole);

        // Method to delete a user based on their ID
        void DeleteRole(int RoleId);
    }
}