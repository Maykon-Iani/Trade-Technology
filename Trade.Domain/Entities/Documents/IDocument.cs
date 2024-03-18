using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Trade.Domain.Entities.Documents
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; }
    }
}
