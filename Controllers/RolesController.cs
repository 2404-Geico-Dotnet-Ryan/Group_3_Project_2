using Project2.DTOs;
using Project2.Services;
using Microsoft.AspNetCore.Mvc;


namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        // Constructor to inject the role service
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: /Roles
        // Action method to handle GET requests to retrieve all roles
        [HttpGet]
        public ActionResult<IEnumerable<RoleDTO>> GetAllRoles()
        {
            var roles = _roleService.GetAllRoles();
            return Ok(roles);
        }

        // GET: /Roles/{RoleId}
        // Action method to handle GET requests to retrieve a role by their ID
        [HttpGet("{RoleId}")]
        public ActionResult<RoleDTO> GetRoleById(int RoleId)
        {
            var role = _roleService.GetRoleById(RoleId);
            return role;
        }

        // POST: /Roles
        // Action method to handle POST requests to create a new role
        [HttpPost]
        public ActionResult<RoleDTO> PostRole(RoleDTO roleDto)
        {
            var role = _roleService.CreateRole(roleDto);
            return CreatedAtAction(nameof(GetRoleById), new { RoleId = role.RoleId }, roleDto);
        }

        // PUT: /Roles/{RoleId}
        // Action method to handle PUT requests to update an existing role
        [HttpPut("{RoleId}")]
        public ActionResult<RoleDTO> UpdateRole(int RoleId, RoleDTO UpdatedRole)
        {
            _roleService.UpdatedRole(RoleId, UpdatedRole);
            return Ok(UpdatedRole);
        }

        // DELETE: /Roles/{RoleId}
        // Action method to handle DELETE requests to delete a role by their ID
        [HttpDelete("{RoleId}")]
        public IActionResult DeleteRole(int RoleId)
        {
            _roleService.DeleteRole(RoleId);
            return Ok();
        }
    }
}