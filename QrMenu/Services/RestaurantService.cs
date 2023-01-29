using QrMenu.Data.Repositories;
using QrMenu.Models;

namespace QrMenu.Services
{
    public class RestaurantService:IRestaurantService
	{
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            return await restaurantRepository.GetAllRestaurants();
        }

        public async Task<Restaurant> GetRestaurant(string id)
        {
            return await restaurantRepository.GetRestaurant(id);
        }

        public async Task<bool> AddRestaurant(Restaurant restaurant)
        {
            return await restaurantRepository.AddRestaurant(restaurant);
        }

        public async Task<bool> UpdateRestaurant(string id, Restaurant restaurant)
        {
            return await restaurantRepository.UpdateRestaurant(id, restaurant);
        }

        public async Task<bool> RemoveRestaurant(string id)
        {
           return await restaurantRepository.RemoveRestaurant(id);
        }

    }
}

