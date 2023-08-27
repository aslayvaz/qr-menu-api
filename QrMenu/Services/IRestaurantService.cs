using QrMenu.Models.Restaurant;

namespace QrMenu.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
        Task<Restaurant> GetRestaurant(string id);
        Task<Restaurant> AddRestaurant(RestaurantInsert insertModel);
        Task<bool> UpdateRestaurant(string id, Restaurant restaurant);
        Task<bool> RemoveRestaurant(string id);

    }
}

