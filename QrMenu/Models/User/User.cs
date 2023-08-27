using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QrMenu.Models.User
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("username")]
        public string? Username { get; set; }

        [BsonElement("password")]
        public string? Password { get; set; }

        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("isAdmin")]
        public bool IsAdmin { get; set; } = false;

        [BsonElement("isActive")]
        public bool IsActive { get; set; } = false;

        [BsonElement("isMailConfirmed")]
        public bool IsMailConfirmed { get; set; } = false;

        [BsonElement("create_date")]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [BsonElement("last_edit_date")]
        public DateTime? LastEditDate { get; set; }



    }

}

