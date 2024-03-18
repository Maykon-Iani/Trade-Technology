using MongoDB.Bson;

namespace Trade.Domain.Entities.Documents
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => DateTime.Now;
    }
}
