namespace MyFirstApi.EFCore.Entities
{
    public class Address
    {
        public int AddressID { get; set; }
        public int CustomerID { get; set; }  // Foreign key
        public string Line1 { get; set; }
        public string? Line2 { get; set; } = null!; // Optional
        public string City { get; set; }
        public string State { get; set; }  // Consider creating an enum for states
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public bool Disabled { get; set; }

        // Navigation property
        public Customer Customer { get; set; }
    }
}
