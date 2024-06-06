using Project2.DTOs;
using Project2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Project2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        // Constructor to inject the food service
        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        // GET: /Foods
        // Action method to handle GET requests to retrieve all foods
        [HttpGet]
        public ActionResult<IEnumerable<FoodDTO>> GetFoods()
        {
            var foods = _foodService.GetAllFoods();
            return Ok(foods);
        }

        // GET: /Foods/{FoodId}
        // Action method to handle GET requests to retrieve a food by their ID
        [HttpGet("{FoodId}")]
        public ActionResult<FoodDTO> GetFoodById(int FoodId)
        {
            var food = _foodService.GetFoodById(FoodId);
            return food;
        }

        // POST: /Foods
        // Action method to handle POST requests to create a new food
        [HttpPost]
        public ActionResult<FoodDTO> PostFood(FoodDTO foodDto)
        {
            var food = _foodService.CreateFood(foodDto);
            return CreatedAtAction(nameof(GetFoodById), new { FoodId = food.FoodId }, foodDto);
        }

        // PUT: /Foods/{FoodId}
        // Action method to handle PUT requests to update an existing food
        [HttpPut("{FoodId}")]
        public ActionResult<FoodDTO> UpdateFood(int FoodId, FoodDTO UpdatedFood)
        {
            _foodService.UpdatedFood(FoodId, UpdatedFood);
            return Ok(UpdatedFood);
        }

        // DELETE: /Foods/{FoodId}
        // Action method to handle DELETE requests to delete a food by their ID
        [HttpDelete("{FoodId}")]
        public IActionResult DeleteFood(int FoodId)
        {
            _foodService.DeleteFood(FoodId);
            return Ok();
        }
    }
}