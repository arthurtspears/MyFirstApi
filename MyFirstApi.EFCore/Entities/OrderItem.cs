using MyFirstApi.EFCore.Abstract;

namespace MyFirstApi.EFCore.Entities
{
    public class OrderItem : EntityBase<int>
    { 
        public int OrderID { get; init; }     // Foreign key
        public int ProductID { get; init; }   // Foreign key
        public decimal ItemPrice { get; init; }
        public decimal DiscountAmount { get; init; }
        public int Quantity { get; init; }

        // Navigation properties
        public Order Order { get; init; }
        public Product Product { get; init; }
    }
}
