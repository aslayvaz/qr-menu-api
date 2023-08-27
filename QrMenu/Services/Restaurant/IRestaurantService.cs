using QrMenu.Models.Restaurant;
using QrMenu.ViewModels.Restaurant;

namespace QrMenu.Services.Restaurant
{
    public interface IRestaurantService
    {
        Task<IEnumerable<RestaurantView>> GetAllRestaurants();
        Task<RestaurantDatabaseModel> GetRestaurant(string id);
        Task<RestaurantDatabaseModel> AddRestaurant(RestaurantInsert insertModel);
        Task<bool> UpdateRestaurant(string id, RestaurantDatabaseModel restaurant);
        Task<bool> RemoveRestaurant(string id);
        Task<bool> RemoveAllRestaurant();
    }
}

