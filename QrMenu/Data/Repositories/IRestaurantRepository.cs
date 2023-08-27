using QrMenu.Models.Restaurant;

namespace QrMenu.Data.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<RestaurantDatabaseModel>> GetAllRestaurants();
        Task<RestaurantDatabaseModel> GetRestaurant(string id);
        Task<RestaurantDatabaseModel> AddRestaurant(RestaurantDatabaseModel restaurant);
        Task<bool> UpdateRestaurant(string id, RestaurantDatabaseModel restaurant);
        Task<bool> RemoveRestaurant(string id);
        Task<RestaurantDatabaseModel> GetRestaurantByName(string name);
        Task<bool> RemoveAllRestaurant();
    }

}

