using QrMenu.Data.Repositories;
using QrMenu.Models.Restaurant;
using QrMenu.Utils.Mapping;
using QrMenu.ViewModels.Restaurant;

namespace QrMenu.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            this.restaurantRepository = restaurantRepository;
        }

        public async Task<IEnumerable<RestaurantView>> GetAllRestaurants()
        {
            var restaurants = await restaurantRepository.GetAllRestaurants();

            return restaurants.Map<List<Restaurant>, List<RestaurantView>>();
        }

        public async Task<Restaurant> GetRestaurant(string id)
        {
            var restaurant = await restaurantRepository.GetRestaurant(id);

            return restaurant;
        }

        public async Task<Restaurant> AddRestaurant(RestaurantInsert insertModel)
        {
            var exists = await restaurantRepository.GetRestaurantByName(insertModel.Name);

            if (exists is not null) return null;

            var restaurant = insertModel.Map<RestaurantInsert, Restaurant>();

            restaurant.CreateTime = DateTime.Now;

            return await restaurantRepository.AddRestaurant(restaurant);
        }

        public async Task<bool> UpdateRestaurant(string id, Restaurant restaurant)
        {
            var notExists = await restaurantRepository.GetRestaurant(restaurant.Id) == null;

            if (notExists) return false;

            return await restaurantRepository.UpdateRestaurant(id, restaurant);
        }

        public async Task<bool> RemoveRestaurant(string id)
        {
            return await restaurantRepository.RemoveRestaurant(id);
        }

        public async Task<bool> RemoveAllRestaurant()
        {
            return false;
            return await restaurantRepository.RemoveAllRestaurant();
        }
    }
}

