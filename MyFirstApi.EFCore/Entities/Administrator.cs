using System.ComponentModel.DataAnnotations;
using MyFirstApi.EFCore.Abstract;

namespace MyFirstApi.EFCore.Entities
{
    public class Administrator : EntityBase<int>
    {
        [MaxLength(255)]
        public string EmailAddress { get; init; }

        [MaxLength(255)]
        public string Password { get; init; }  // Consider hashing passwords

        [MaxLength(255)]
        public string FirstName { get; init; }

        [MaxLength(255)]
        public string LastName { get; init; }
    }
}
