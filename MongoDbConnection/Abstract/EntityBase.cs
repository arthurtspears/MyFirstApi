using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbConnection.Abstract
{
    public abstract class EntityBase<TKey>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public TKey Id { get; init; }
    }
}
