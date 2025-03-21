using System.ComponentModel.DataAnnotations;
using MyFirstApi.EFCore.Abstract;

namespace MyFirstApi.EFCore.Entities
{
    public class Address : EntityBase<int>
    {
        [MaxLength(60)]
        public string Line1 { get; init; }

        [MaxLength(60)]
        public string? Line2 { get; init; } = null!; // Optional

        [MaxLength(40)]
        public string City { get; init; }

        [MaxLength(2)]
        public string State { get; init; }  // Consider creating an enum for states

        [MaxLength(10)]
        public string ZipCode { get; init; }

        [MaxLength(12)]
        public string Phone { get; init; }

        public bool Disabled { get; init; } = false;
    }
}
