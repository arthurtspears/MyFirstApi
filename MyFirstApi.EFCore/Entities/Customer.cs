namespace MyFirstApi.EFCore.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }  // Consider hashing passwords in a real app
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ShippingAddressID { get; set; }  // Nullable foreign key
        public int? BillingAddressID { get; set; }   // Nullable foreign key

        // Navigation properties
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
