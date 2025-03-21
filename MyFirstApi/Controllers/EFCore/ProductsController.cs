//using Microsoft.AspNetCore.Mvc;
//using MyFirstApi.EFCore.Entities;
//using MyFirstApi.EFCore.Services;

//namespace MyFirstApi.Controllers.EFCore
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class ProductsController(
//        ILogger<ProductsController> logger,
//        ProductService service)
//        : ControllerBase
//    {
//        private readonly ILogger<ProductsController> _logger = logger;

//        [HttpGet]
//        public async Task<IActionResult> GetProducts()
//        {
//            try
//            {
//                var products = await service.GetAllAsync();

//                return Ok(products);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal Server Error: {ex.Message}");
//            }
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetProductAsync(int id)
//        {
//            try
//            {
//                var product = await service.GetByIdAsync(id);

//                return Ok(product);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal Server Error: {ex.Message}");
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> PostProductAsync([FromBody] Product newProduct)
//        {
//            try
//            {
//                var product = await service.CreateAsync(newProduct);

//                return Ok(product);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal Server Error: {ex.Message}");
//            }
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutProduct([FromBody] Product newProduct, int id)
//        {
//            try
//            {
//                if (await service.UpdateAsync(id, newProduct))
//                {
//                    await service.UpdateAsync(id, newProduct);

//                    return Ok();
//                }
//                throw new Exception($"Product not found for id: {id}");
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal Server Error: {ex.Message}");
//            }
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteProductByIdAsync(int id)
//        {
//            try
//            {
//                if (await service.DeleteAsync(id))
//                {
//                    return Ok();
//                }
//                throw new Exception($"Product not found for id: {id}");
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal Server Error: {ex.Message}");
//            }
//        }
//    }
//}
