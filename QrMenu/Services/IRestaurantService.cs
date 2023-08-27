using QrMenu.Models.Restaurant;
using QrMenu.ViewModels.Restaurant;

namespace QrMenu.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantView>> GetAllRestaurants();
        Task<Restaurant> GetRestaurant(string id);
        Task<Restaurant> AddRestaurant(RestaurantInsert insertModel);
        Task<bool> UpdateRestaurant(string id, Restaurant restaurant);
        Task<bool> RemoveRestaurant(string id);
        Task<bool> RemoveAllRestaurant();
    }
}

