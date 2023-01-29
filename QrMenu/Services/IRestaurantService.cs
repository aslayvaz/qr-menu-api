using System;
using QrMenu.Models;

namespace QrMenu.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
        Task<Restaurant> GetRestaurant(string id);
        Task<bool> AddRestaurant(Restaurant restaurant);
        Task<bool> UpdateRestaurant(string id, Restaurant restaurant);
        Task<bool> RemoveRestaurant(string id);

    }
}

