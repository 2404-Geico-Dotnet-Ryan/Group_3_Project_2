using Project2.Data;
using Project2.DTOs;
using Project2.Models;

namespace Project2.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;

        // Constructor to inject the database context
        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        // Method to create a new Role based on the provided RoleDTO
        public Role CreateRole(RoleDTO RoleDto)
        {
            if (ValidateNewRole(RoleDto))
            {
                var Role = new Role
                {
                    RoleId = RoleDto.RoleId,
                    UserType = RoleDto.UserType

                };

                _context.Roles.Add(Role);
                _context.SaveChanges();

                return Role;
            }
            else
            {
                throw new Exception("Invalid Role");
            }
        }

        // Private method to validate the new Role data
        private bool ValidateNewRole(RoleDTO RoleDto)
        {
            return !string.IsNullOrWhiteSpace(RoleDto.UserType);
        }

        // Method to delete a Role based on their ID
        public void DeleteRole(int RoleId)
        {
            var Role = _context.Roles.FirstOrDefault(r => r.RoleId ==RoleId);

            if (Role != null)
            {
                _context.Roles.Remove(Role);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Role not found");
            }
        }

        // Method to get a list of all Roles
        public IEnumerable<RoleDTO> GetAllRoles()
        {
            var roles = _context.Roles
                .Select(r => new RoleDTO
                {
                    RoleId = r.RoleId,
                    UserType = r.UserType
                    
                }).ToList();

            return roles;
        }

        // Method to get a specific Role by their ID
        public RoleDTO GetRoleById(int RoleId)
        {
            var Role = _context.Roles.Find(RoleId);

            if (Role != null)
            {
                var roleDto = new RoleDTO
                {
                    RoleId = Role.RoleId,
                    UserType = Role.UserType
                };

                return roleDto;
            }
            else
            {
                throw new Exception("Role not found");
            }
        }

        // Method to update an existing Role based on their ID and the provided updated RoleDTO
        public void UpdatedRole(int RoleId, RoleDTO UpdatedRole)
        {
            var role = _context.Roles.FirstOrDefault(r => r.RoleId == RoleId);

            if (role != null)
            {
                role.RoleId = UpdatedRole.RoleId;
                role.UserType = UpdatedRole.UserType;
                

                _context.Roles.Update(role);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Role not found");
            }
        }
    }

}