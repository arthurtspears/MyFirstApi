using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Common.Interfaces.Services;

namespace MyFirstApi.Abstract
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController<TEntity, TKey>(
        IService<TEntity, TKey> service,
        ILogger<BaseController<TEntity, TKey>> logger)
        : ControllerBase where TEntity : class
    {
        protected readonly IService<TEntity, TKey> _service = service;
        protected readonly ILogger _logger = logger;

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var entities = await _service.GetAllAsync();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all entities");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(TKey id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);
                if (entity == null)
                    return NotFound();

                return Ok(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching entity with id {id}");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TEntity entity)
        {
            try
            {
                var createdEntity = await _service.CreateAsync(entity);
                return Ok(createdEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating entity");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(TKey id, [FromBody] TEntity entity)
        {
            try
            {
                var updated = await _service.UpdateAsync(id, entity);
                if (!updated)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating entity with id {id}");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(TKey id)
        {
            try
            {
                var deleted = await _service.DeleteAsync(id);
                if (!deleted)
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting entity with id {id}");
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
    }
}
