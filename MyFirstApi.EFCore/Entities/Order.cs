using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApi.EFCore.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }        // Foreign key
        public DateTime OrderDate { get; set; }
        public decimal ShipAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public DateTime? ShipDate { get; set; }
        public int ShipAddressID { get; set; }     // Foreign key
        public string CardType { get; set; }
        public string CardNumber { get; set; }     // Consider encryption
        public DateTime CardExpires { get; set; }
        public int BillingAddressID { get; set; }  // Foreign key

        // Navigation properties
        public Customer Customer { get; set; }
        public Address ShipAddress { get; set; }
        public Address BillingAddress { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
