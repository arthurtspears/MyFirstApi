using Microsoft.EntityFrameworkCore;
using MyFirstApi.Common.Interfaces.Services;
using MyFirstApi.EFCore.Data;

namespace MyFirstApi.EFCore.Abstract
{
    public abstract class ServiceBase<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : EntityBase<TKey>
    {

        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected ServiceBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<TEntity?> GetByIdAsync(TKey id) => 
            await _dbSet.FindAsync(id);

        public virtual async Task<IList<TEntity>> GetAllAsync() =>
            await _dbSet.ToListAsync();

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> UpdateAsync(TKey id, TEntity entity)
        {
            var existingEntity = await _dbSet.FindAsync(id);
            if (existingEntity == null) return false;

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<bool> DeleteAsync(TKey id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) return false;   

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
