using Project2.Data;
using Project2.DTOs;
using Project2.Models;

namespace Project2.Services
{
    public class FoodService : IFoodService
    {
        private readonly AppDbContext _context;

        // Constructor to inject the database context
        public FoodService(AppDbContext context)
        {
            _context = context;
        }

        // Method to create a new food based on the provided FoodDTO
        public Food CreateFood(FoodDTO FoodDto)
        {
            if (ValidateNewFood(FoodDto))
            {
                var food = new Food
                {
                    ItemName = FoodDto.ItemName,
                    Price = FoodDto.Price,
                    FoodQuantity = FoodDto.FoodQuantity,
                    InStock = FoodDto.InStock
                };

                _context.Foods.Add(food);
                _context.SaveChanges();

                return food;
            }
            else
            {
                throw new Exception("Invalid Food");
            }
        }

        // Private method to validate the new food data
        private bool ValidateNewFood(FoodDTO FoodDto)
        {
            return !string.IsNullOrWhiteSpace(FoodDto.ItemName);
        }

        // Method to delete a food based on their ID
        public void DeleteFood(int FoodId)
        {
            var food = _context.Foods.FirstOrDefault(f => f.FoodId == FoodId);

            if (food != null)
            {
                _context.Foods.Remove(food);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Food not found");
            }
        }

        // Method to get a list of all foods
        public IEnumerable<FoodDTO> GetAllFoods()
        {
            var foods = _context.Foods
                .Select(f => new FoodDTO
                {
                    FoodId = f.FoodId,
                    ItemName = f.ItemName,
                    Price = f.Price,
                    FoodQuantity = f.FoodQuantity,
                    InStock = f.InStock
                }).ToList();

            return foods;
        }

        // Method to get a specific food by their ID
        public FoodDTO GetFoodById(int FoodId)
        {
            var food = _context.Foods.Find(FoodId);

            if (food != null)
            {
                var foodDto = new FoodDTO
                {
                    FoodId = food.FoodId,
                    ItemName = food.ItemName,
                    Price = food.Price,
                    FoodQuantity = food.FoodQuantity,
                    InStock = food.InStock
                    
                };

                return foodDto;
            }
            else
            {
                throw new Exception("Food not found");
            }
        }

        // Method to update an existing food based on their ID and the provided updated FoodDTO
        public void UpdatedFood(int FoodId, FoodDTO UpdatedFood)
        {
            var food = _context.Foods.FirstOrDefault(u => u.FoodId == FoodId);

            if (food != null)
            {
                food.ItemName = UpdatedFood.ItemName;
                food.Price = UpdatedFood.Price;
                food.FoodQuantity = UpdatedFood.FoodQuantity;
                food.InStock = UpdatedFood.InStock;

                _context.Foods.Update(food);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Food not found");
            }
        }

    }

}