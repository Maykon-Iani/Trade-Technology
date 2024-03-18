using MongoDB.Bson.Serialization.Attributes;
using Trade.Domain.Entities.Documents;
using Trade.Domain.Helpers;

namespace Trade.Domain.Entities
{
    [BsonCollection("users")]
    public class User : Document
    {
        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }

    }
}
