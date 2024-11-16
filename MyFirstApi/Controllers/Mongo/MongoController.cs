using Microsoft.AspNetCore.Mvc;
using MongoDbConnection.Services;

namespace MyFirstApi.Controllers.Mongo
{
    [ApiController]
    [Route("[controller]")]
    public class MongoController(
        ILogger<MongoController> logger,
        ConnectionService service)
        : ControllerBase
    {
        private readonly ILogger<MongoController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> HealthCheck()
        {
            try
            {
                if (await service.HealthCheck())
                {
                    return Ok();
                }
                return StatusCode(500, $"Unable to health check Mongo");
            }
            catch (Exception ex)
            {
                logger.LogError("Unable to contact MongoDb");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
