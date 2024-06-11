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
        public  ActionResult<UserLoginDTO> LoginUser(UserLoginDTO userLogin)
            {
                var user = _userService.LoginUser(userLogin);

                // if the username or password was not valid, we will get back a null user
                // based on that, we can send back a response telling the client that it was invalid
                if (user == null)
                {
                    return Ok("Invalid Login, please try again!");
                }       
                return userLogin;
                // When a user logs in, if you have some kind of role property, this is where you would add it
                // Since I do not have it, I'm going to hard code it
                // Response.Headers.Append("Authorization", "Admin"); first attempt, we cannot access custom headers in cors responses
                // Instead, we will add it to the response body
        
                // return new LoginResponseDTO
                // {
                // UserName = user.value.username,
                // Authorization = "Admin"
                // };
            }

            [HttpGet("protected")]
             public async Task<IActionResult> ProtectedEndpoint([FromHeader] string Authorization)
                {
                    if(Authorization == "Admin"){
                         return Ok("Hi there admin!");
                    }else{
                        return Unauthorized("You are not an admin!");
                        }
                }
        }
    }
