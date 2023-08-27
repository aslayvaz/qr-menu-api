using MongoDB.Driver;
using QrMenu.Models.Restaurant;

namespace QrMenu.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IMongoCollection<Restaurant> restaurants;

        public RestaurantRepository(IMongoDatabase database)
        {
            restaurants = database.GetCollection<Restaurant>("restaurants");
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            var restaurantList = await restaurants.Find(r => true).ToListAsync();

            if (restaurantList == null) return null;

            return restaurantList;
        }

        public async Task<Restaurant> GetRestaurant(string id)
        {
            var restaurant = await restaurants.Find(u => u.Id == id).FirstOrDefaultAsync();

            if (restaurant is null) return null;

            return restaurant;
        }

        public async Task<Restaurant> AddRestaurant(Restaurant restaurant)
        {
            try
            {
                await restaurants.InsertOneAsync(restaurant);


            }
            catch
            {
                return null;
            }
            return restaurant;
        }

        public async Task<bool> UpdateRestaurant(string id, Restaurant restaurant)
        {
            var updateResult = await restaurants.ReplaceOneAsync(r => r.Id == id, restaurant);
            return updateResult.IsAcknowledged;
        }

        public async Task<bool> RemoveRestaurant(string id)
        {
            var deleteResult = await restaurants.DeleteOneAsync(r => r.Id == id);
            return deleteResult.IsAcknowledged;
        }

        public async Task<Restaurant> GetRestaurantByName(string name)
        {
            var restaurant = await restaurants.Find(u => u.RestaurantName == name).FirstOrDefaultAsync();

            if (restaurant is null) return null;

            return restaurant;
        }
    }
}

