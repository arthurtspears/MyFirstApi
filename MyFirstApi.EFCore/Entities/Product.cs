using MyFirstApi.EFCore.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.EFCore.Entities
{
    public class Product : EntityBase<int>
    {
        public int CategoryID { get; init; }  // Foreign key

        [MaxLength(10)]
        public string? ProductCode { get; init; }

        [MaxLength(255)]
        public string? ProductName { get; init; }
        public string? Description { get; init; }
        public decimal ListPrice { get; init; }
        public decimal DiscountPercent { get; init; }
        public DateTime DateAdded { get; init; } = DateTime.UtcNow;

        // Navigation properties
        public Category Category { get; init; } = null!;
        public ICollection<OrderItem>? OrderItems { get; init; }
    }
}
