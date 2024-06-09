using Project2.DTOs;
using Project2.Models;


namespace Project2.Services
{
    public interface IFoodService
    {
        // Method to get a list of all users
        IEnumerable<FoodDTO> GetAllFoods();

        // Method to get a specific user by their ID
        FoodDTO GetFoodById(int FoodId);

        // Method to create a new user based on the provided FoodDTO
        Food CreateFood(FoodDTO FoodDto);

        // Method to update an existing user based on their ID and the provided updated FoodDTO
        void UpdatedFood(int FoodId, FoodDTO UpdatedFood);

        // Method to delete a user based on their ID
        void DeleteFood(int FoodId);
    }
}