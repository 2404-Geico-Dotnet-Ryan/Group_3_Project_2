using Project2.DTOs;
using Project2.Models;

namespace Project2.Services
{
    public interface IUserService
    {
        // Method to get a list of all users
        IEnumerable<UserDTO> GetAllUsers();

        // Method to get a specific user by their ID
        UserDTO GetUserById(int UserId);

        // Method to create a new user based on the provided UserDTO
        User CreateUser(UserDTO UserDto);

        // Method to update an existing user based on their ID and the provided updated UserDTO
        void UpdatedUser(int UserId, UserDTO UpdatedUser);

        // Method to delete a user based on their ID
        void DeleteUser(int UserId);
       
       User LoginUser(UserLoginDTO userLogin);
    }
}