using MongoDB.Driver;

namespace MyFirstApi.MongoDbConnection
{
    public class MongoConnectionService
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDatabase;

        public MongoConnectionService(IMongoClient mongoClient)
        {
            _mongoClient = mongoClient;
            _mongoDatabase = _mongoClient.GetDatabase("MyGuitarShop");
        }
    }
}
