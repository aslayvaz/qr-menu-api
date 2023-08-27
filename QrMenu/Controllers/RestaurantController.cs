using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QrMenu.Models.Restaurant;
using QrMenu.Services;

namespace QrMenu.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var restaurants = await restaurantService.GetAllRestaurants();
            return Ok(restaurants);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var restaurant = await restaurantService.GetRestaurant(id);
            if (restaurant == null)
                return NotFound();

            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RestaurantInsert restaurant)
        {
            var addedRestaurant = await restaurantService.AddRestaurant(restaurant);

            return CreatedAtAction(nameof(Get), new { id = addedRestaurant.Id }, addedRestaurant);
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

