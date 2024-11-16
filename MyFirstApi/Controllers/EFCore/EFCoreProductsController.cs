using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Abstract;
using MyFirstApi.EFCore.Entities;
using MyFirstApi.EFCore.Services;

namespace MyFirstApi.Controllers.EFCore
{
    [ApiController]
    [Route("[controller]")]
    public class EfCoreProductsController(ProductService service, ILogger<EfCoreProductsController> logger) : BaseController<Product, int>(service, logger);

}
