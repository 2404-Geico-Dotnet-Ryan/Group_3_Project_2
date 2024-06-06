using Project2.Data;
using Project2.DTOs;
using Project2.Models;

namespace Project2.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        // Constructor to inject the database context
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // Method to create a new user based on the provided UserDTO
        public User CreateUser(UserDTO UserDto)
        {
            if (ValidateNewUser(UserDto))
            {
                var user = new User
                {
                    UserName = UserDto.UserName
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                return user;
            }
            else
            {
                throw new Exception("Invalid User");
            }
        }

        // Private method to validate the new user data
        private bool ValidateNewUser(UserDTO UserDto)
        {
            return !string.IsNullOrWhiteSpace(UserDto.UserName);
        }

        // Method to delete a user based on their ID
        public void DeleteUser(int UserId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == UserId);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        // Method to get a list of all users
        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _context.Users
                .Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    UserName = u.UserName
                }).ToList();

            return users;
        }

        // Method to get a specific user by their ID
        public UserDTO GetUserById(int UserId)
        {
            var user = _context.Users.Find(UserId);

            if (user != null)
            {
                var userDto = new UserDTO
                {
                    UserName = user.UserName,
                    UserId = user.UserId
                };

                return userDto;
            }
            else
            {
                throw new Exception("User not found");
            }
        }

        // Method to update an existing user based on their ID and the provided updated UserDTO
        public void UpdatedUser(int UserId, UserDTO UpdatedUser)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == UserId);

            if (user != null)
            {
                user.UserName = UpdatedUser.UserName;

                _context.Users.Update(user);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("User not found");
            }
        }

    }

}