using MyFirstApi.EFCore.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.EFCore.Entities
{
    public class Customer : EntityBase<int>
    {
        public int? ShippingAddressID { get; init; } = null!;// Nullable foreign key
        public int? BillingAddressID { get; init; } = null!;  // Nullable foreign key

        [MaxLength(255)]
        public string EmailAddress { get; init; }

        [MaxLength(60)]
        public string Password { get; init; }  // Consider hashing passwords in a real app

        [MaxLength(60)]
        public string FirstName { get; init; }

        [MaxLength(60)]
        public string LastName { get; init; }

        // Navigation properties
        public Address? ShippingAddress { get; init; }
        public Address? BillingAddress { get; init; }
        public ICollection<Order>? Orders { get; init; }
    }
}
