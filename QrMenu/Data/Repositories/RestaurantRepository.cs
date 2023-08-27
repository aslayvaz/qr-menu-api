using MongoDB.Driver;
using QrMenu.Models.Restaurant;

namespace QrMenu.Data.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly IMongoCollection<RestaurantDatabaseModel> restaurants;

        public RestaurantRepository(IMongoDatabase database)
        {
            restaurants = database.GetCollection<RestaurantDatabaseModel>("restaurants");
        }

        public async Task<List<RestaurantDatabaseModel>> GetAllRestaurants()
        {
            var restaurantList = await restaurants.Find(r => true).ToListAsync();

            if (restaurantList == null) return null;

            return restaurantList;
        }

        public async Task<RestaurantDatabaseModel> GetRestaurant(string id)
        {
            var restaurant = await restaurants.Find(u => u.Id == id).FirstOrDefaultAsync();

            if (restaurant is null) return null;

            return restaurant;
        }

        public async Task<RestaurantDatabaseModel> AddRestaurant(RestaurantDatabaseModel restaurant)
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

        public async Task<bool> UpdateRestaurant(string id, RestaurantDatabaseModel restaurant)
        {
            var updateResult = await restaurants.ReplaceOneAsync(r => r.Id == id, restaurant);
            return updateResult.IsAcknowledged;
        }

        public async Task<bool> RemoveRestaurant(string id)
        {
            var deleteResult = await restaurants.DeleteOneAsync(r => r.Id == id);
            return deleteResult.IsAcknowledged;
        }

        public async Task<RestaurantDatabaseModel> GetRestaurantByName(string name)
        {
            var restaurant = await restaurants.Find(u => u.Name == name).FirstOrDefaultAsync();

            if (restaurant is null) return null;

            return restaurant;
        }

        public async Task<bool> RemoveAllRestaurant()
        {
            var deleteResult = await restaurants.DeleteManyAsync(Builders<RestaurantDatabaseModel>.Filter.Empty);
            return deleteResult.IsAcknowledged;
        }
    }
}

