using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QrMenu.Models.Restaurant
{

    public class Restaurant
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("restaurant_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? RestaurantId { get; set; }

        [BsonElement("restaurant_name")]
        public string? RestaurantName { get; set; }

        [BsonElement("phone_number")]
        public string? PhoneNumber { get; set; }

        [BsonElement("phone_number_2")]
        public string? PhoneNumber2 { get; set; }

        [BsonElement("website")]
        public string? Website { get; set; }

        [BsonElement("address")]
        public string? Address { get; set; }

        [BsonElement("menu_link")]
        public string? MenuLink { get; set; }

        [BsonElement("social_link")]
        public string? SocialLink { get; set; }

        [BsonElement("social_link_2")]
        public string? SocialLink2 { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [BsonElement("create_date")]
        public DateTime CreateTime { get; set; }
    }

}

