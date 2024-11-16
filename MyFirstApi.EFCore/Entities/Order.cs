using MyFirstApi.EFCore.Abstract;

namespace MyFirstApi.EFCore.Entities
{
    public class Order : EntityBase<int>
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }        // Foreign key
        public int BillingAddressID { get; set; }  // Foreign key
        public int ShipAddressID { get; set; }     // Foreign key

        public DateTime OrderDate { get; set; }
        public decimal ShipAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime? ShipDate { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }     // Consider encryption
        public DateTime CardExpires { get; set; }

        // Navigation properties
        public Customer Customer { get; set; }
        public Address ShipAddress { get; set; }
        public Address BillingAddress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
