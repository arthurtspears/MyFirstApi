namespace MyFirstApi.EFCore.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        // Navigation property
        public ICollection<Product> Products { get; set; }
    }
}
