using MongoDB.Driver;
using MyFirstApi.Common.Interfaces.Services;

namespace MongoDbConnection.Abstract
{
    public abstract class ServiceBase<TEntity, TKey>(IMongoDatabase database) : IService<TEntity, TKey>
        where TEntity: EntityBase<TKey>
    {
        private readonly IMongoCollection<TEntity> _entities = database.GetCollection<TEntity>(nameof(TEntity));
        
        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _entities.Find(f => Equals(f.Id, id)).FirstOrDefaultAsync();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _entities.Find(_ => true).ToListAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _entities.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> UpdateAsync(TKey id, TEntity entity)
        {
            var result = await _entities.ReplaceOneAsync(f => Equals(f.Id, id), entity);
            return result.IsAcknowledged;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            var result = await _entities.DeleteOneAsync(f => Equals(f.Id, id));
            return result.IsAcknowledged;
        }
    }
}
