namespace MyFirstApi.EFCore.Entities
{
    public class Administrator
    {
        public int AdminID { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }  // Consider hashing passwords
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
