using System;
using QrMenu.Models;

namespace QrMenu.Data.Repositories
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllRestaurants();
        Task<Restaurant> GetRestaurant(string id);
        Task<bool> AddRestaurant(Restaurant restaurant);
        Task<bool> UpdateRestaurant(string id, Restaurant restaurant);
        Task<bool> RemoveRestaurant(string id);
    }

}

