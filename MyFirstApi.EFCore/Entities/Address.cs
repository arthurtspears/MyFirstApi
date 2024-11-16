using System.ComponentModel.DataAnnotations;
using MyFirstApi.EFCore.Abstract;

namespace MyFirstApi.EFCore.Entities
{
    public class Address : EntityBase<int>
    {
        public int CustomerID { get; set; }  // Foreign key

        [MaxLength(60)]
        public string Line1 { get; set; }

        [MaxLength(60)]
        public string? Line2 { get; set; } // Optional

        [MaxLength(40)]
        public string City { get; set; }

        [MaxLength(2)]
        public string State { get; set; }  // Consider creating an enum for states

        [MaxLength(10)]
        public string ZipCode { get; set; }

        [MaxLength(12)]
        public string Phone { get; set; }

        public bool Disabled { get; set; }

        // Navigation property
        public Customer Customer { get; set; }
    }
}
