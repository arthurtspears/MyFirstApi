using Microsoft.AspNetCore.Mvc;
using MyFirstApi.EFCore.Data;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController(ILogger<ProductsController> logger,
        ApplicationDbContext context) : ControllerBase
    {
        //private readonly ILogger<ProductsController> _logger;
        //private readonly ApplicationDbContext _context;

        //public ProductsController
        //{
        //    _logger = logger;
        //    _context = context;
        //}

        [HttpGet]
        public IActionResult GetProducts()
        {
            try
            {
                var products = _context.Products.ToList();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
