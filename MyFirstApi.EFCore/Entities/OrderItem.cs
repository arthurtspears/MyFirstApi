using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApi.EFCore.Entities
{
    public class OrderItem
    {
        public int ItemID { get; set; }
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
