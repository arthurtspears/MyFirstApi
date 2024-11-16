using MyFirstApi.EFCore.Abstract;
using MyFirstApi.EFCore.Data;
using MyFirstApi.EFCore.Entities;

namespace MyFirstApi.EFCore.Services
{
    public class ProductService(ApplicationDbContext context) : ServiceBase<Product, int>(context)
    { }
    
    public class CategoryService(ApplicationDbContext context) : ServiceBase<Category, int>(context)
    { }
}
