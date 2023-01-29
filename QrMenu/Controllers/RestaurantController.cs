using Microsoft.AspNetCore.Mvc;
using QrMenu.Models;
using QrMenu.Services;

namespace QrMenu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestaurantController:ControllerBase
	{
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantService.GetAllRestaurants();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var restaurant = await restaurantService.GetRestaurant(id);
            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Restaurant restaurant)
        {
            await restaurantService.AddRestaurant(restaurant);
            return CreatedAtAction(nameof(Get), new { id = restaurant.Id }, restaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Restaurant restaurant)
        {
            var result = await restaurantService.UpdateRestaurant(id, restaurant);
            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            var result = await restaurantService.RemoveRestaurant(id);
            if (!result)
                return NotFound();

            return Ok();
        }
    }
}

