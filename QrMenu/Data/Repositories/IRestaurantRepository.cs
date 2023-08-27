using QrMenu.Models.Restaurant;

namespace QrMenu.Data.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllRestaurants();
        Task<Restaurant> GetRestaurant(string id);
        Task<Restaurant> AddRestaurant(Restaurant restaurant);
        Task<bool> UpdateRestaurant(string id, Restaurant restaurant);
        Task<bool> RemoveRestaurant(string id);
        Task<Restaurant> GetRestaurantByName(string name);
        Task<bool> RemoveAllRestaurant();
    }

}

