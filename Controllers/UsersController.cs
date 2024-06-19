using Project2.DTOs;
using Project2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        // Constructor to inject the user service
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: /Users
        // Action method to handle GET requests to retrieve all users
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        // GET: /Users/{UserId}
        // Action method to handle GET requests to retrieve a user by their ID
        [HttpGet("{UserId}")]
        public ActionResult<UserDTO> GetUserById(int UserId)
        {
            var user = _userService.GetUserById(UserId);
            return user;
        }

        // POST: /Users
        // Action method to handle POST requests to create a new user
        [HttpPost]
        public ActionResult<UserDTO> PostUser(UserDTO userDto)
        {
            var user = _userService.CreateUser(userDto);
            return CreatedAtAction(nameof(GetUserById), new { UserId = user.UserId }, userDto);
        }

        // PUT: /Users/{UserId}
        // Action method to handle PUT requests to update an existing user
        [HttpPut("{UserId}")]
        public ActionResult<UserDTO> UpdateUser(int UserId, UserDTO UpdatedUser)
        {
            _userService.UpdatedUser(UserId, UpdatedUser);
            return Ok(UpdatedUser);
        }

        // DELETE: /Users/{UserId}
        // Action method to handle DELETE requests to delete a user by their ID
        [HttpDelete("{UserId}")]
        public IActionResult DeleteUser(int UserId)
        {
            _userService.DeleteUser(UserId);
            return Ok();
        }

        // POST: /Users/login
        // Logs in a user
        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(UserDTO userLogin)
        {
            var login = await _userService.LoginUser(userLogin);

            if (login == null)
            {
                return Unauthorized();
            }
            return login;
        }
    }
}
