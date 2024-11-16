using MongoDbConnection.Abstract;

namespace MongoDbConnection.Models
{
    public class Product : EntityBase<string>
    {
        public Category Category{ get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal ListPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime DateAdded { get; init; } = DateTime.UtcNow;
    }
}
