using Microsoft.AspNetCore.Mvc;
using MongoDbConnection.Models;
using MongoDbConnection.Services;
using MyFirstApi.Abstract;

namespace MyFirstApi.Controllers.Mongo
{
    [ApiController]
    [Route("[controller]")]
    public class MongoProductsController(ProductServices service, ILogger<MongoProductsController> logger) : BaseController<Product, string>(service, logger);
}
