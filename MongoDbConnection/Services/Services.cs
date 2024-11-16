using MongoDB.Driver;
using MongoDbConnection.Abstract;
using MongoDbConnection.Models;

namespace MongoDbConnection.Services
{
    public class ConnectionService(IMongoClient client)
    {
        public async Task<bool> HealthCheck()
        {
            var response = await client.ListDatabaseNamesAsync();
            var databaseNames = await response.ToListAsync() ?? [];
            return databaseNames.Any();
        }
    }

    public class ProductServices(IMongoDatabase database) : ServiceBase<Product, string>(database);

    public class CategoryServices(IMongoDatabase database) : ServiceBase<Category, string>(database);
}
