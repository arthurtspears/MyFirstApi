namespace MyFirstApi.EFCore.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }  // Foreign key
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public decimal ListPrice { get; set; }
        public decimal DiscountPercent { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public Category Category { get; set; } = null!;
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
