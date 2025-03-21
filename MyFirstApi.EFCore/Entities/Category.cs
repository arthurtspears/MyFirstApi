using System.ComponentModel.DataAnnotations;
using MyFirstApi.EFCore.Abstract;

namespace MyFirstApi.EFCore.Entities
{
    public class Category : EntityBase<int>
    {
        [MaxLength(255)]
        public string CategoryName { get; init; }

        // Navigation property
        public ICollection<Product>? Products { get; init; }
    }
}
