using MyFirstApi.EFCore.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.EFCore.Entities
{
    public class Order : EntityBase<int>
    {
        public int CustomerID { get; init; }        // Foreign key
        public int ShipAddressID { get; init; }     // Foreign key
        public int BillingAddressID { get; init; }  // Foreign key

        public DateTime OrderDate { get; init; }
        public decimal ShipAmount { get; init; }
        public decimal TaxAmount { get; init; }
        public DateTime? ShipDate { get; init; } = null!;

        [MaxLength(50)]
        public string CardType { get; init; }

        [Length(16,16)]
        public string CardNumber { get; init; }     // Consider encryption

        [Length(7,7)]
        public string CardExpires { get; init; }

        // Navigation properties
        public Customer? Customer { get; init; }
        public Address? ShipAddress { get; init; }
        public Address? BillingAddress { get; init; }
        public ICollection<OrderItem>? OrderItems { get; init; }
    }
}
