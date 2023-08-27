using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QrMenu.Models.ConfirmCode
{
    public class ConfirmCode
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("user_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [BsonElement("confirmation_code")]
        public string Code { get; set; }

        [BsonElement("expires")]
        public DateTime Expires { get; set; }
    }
}

