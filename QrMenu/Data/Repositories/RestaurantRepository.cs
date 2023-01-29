using System;
using MongoDB.Driver;
using QrMenu.Models;

namespace QrMenu.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IMongoCollection<Restaurant> _restaurants;

        public RestaurantRepository(IMongoDatabase database)
        {
            _restaurants = database.GetCollection<Restaurant>("restaurants");
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            var restaurants = await _restaurants.Find(r => true).ToListAsync();

            if (restaurants == null) return null;

            return restaurants;
        }

        public Task<Restaurant> GetRestaurant(string id)
        {
            return Task.FromResult(_restaurants.Find(r => r.Id == id).FirstOrDefault());
        }

        public async Task<bool> AddRestaurant(Restaurant restaurant)
        {
            try
            {
                _restaurants.InsertOneAsync(restaurant);

            }
            catch
            {
                return false;
            }
            return true;
        }

        public Task<bool> UpdateRestaurant(string id, Restaurant restaurant)
        {
            var updateResult = _restaurants.ReplaceOne(r => r.Id == id, restaurant);
            return Task.FromResult(updateResult.IsAcknowledged);
        }

        public Task<bool> RemoveRestaurant(string id)
        {
            var deleteResult = _restaurants.DeleteOne(r => r.Id == id);
            return Task.FromResult(deleteResult.IsAcknowledged);
        }
    }
}

