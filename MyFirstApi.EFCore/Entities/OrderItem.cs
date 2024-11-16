using MyFirstApi.EFCore.Abstract;

namespace MyFirstApi.EFCore.Entities
{
    public class OrderItem : EntityBase<int>
    {
        public int OrderID { get; set; }     // Foreign key
        public int ProductID { get; set; }   // Foreign key
        public decimal ItemPrice { get; set; }
        public decimal DiscountAmount { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
