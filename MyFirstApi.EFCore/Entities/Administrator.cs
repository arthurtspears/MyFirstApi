using MyFirstApi.EFCore.Abstract;

namespace MyFirstApi.EFCore.Entities
{
    public class Administrator : EntityBase<int>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }  // Consider hashing passwords
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
