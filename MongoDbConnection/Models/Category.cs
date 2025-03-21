using MongoDbConnection.Abstract;

namespace MongoDbConnection.Models
{
    public class Category : EntityBase<string>
    {
        public string CategoryName { get; set; }
    }
}
