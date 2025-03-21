namespace MyFirstApi.Common.Interfaces.Services
{
    public interface IService<TEntity, in TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id);                // Retrieve a single entity by ID
        Task<IList<TEntity>> GetAllAsync();                 // Retrieve all entities
        Task<TEntity> CreateAsync(TEntity entity);          // Create a new entity
        Task<bool> UpdateAsync(TKey id, TEntity entity);    // Update an existing entity
        Task<bool> DeleteAsync(TKey id);                    // Delete an entity by ID
    }
}
