using Domain.Entities.Inheritance;
using Infra.Caching;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Infra.Repository.Admin
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        private readonly ICachingService _cache;

        public GenericRepository(AppDbContext context, ICachingService cache)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
            _cache = cache;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            var cache = await _cache.GetAsync(id.ToString());

            if (!string.IsNullOrWhiteSpace(cache))
            {
                return JsonConvert.DeserializeObject<T>(cache);
            }

            var response = await _dbSet.FindAsync(id);

            await _cache.SetAsync(id.ToString(), JsonConvert.SerializeObject(response));

            return response;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var cache = await _cache.GetAsync(typeof(T).FullName);

            if (!string.IsNullOrWhiteSpace(cache))
            {
                return JsonConvert.DeserializeObject<IEnumerable<T>>(cache);
            }

            var response = await _dbSet.ToListAsync();

            await _cache.SetAsync(typeof(T).FullName, JsonConvert.SerializeObject(response));

            return response;
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            OnBeforeSaving();
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            OnBeforeSaving();
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            OnBeforeSaving();
            await _context.SaveChangesAsync();
            return entity;
        }

        private void OnBeforeSaving()
        {
            foreach (var entry in _context.ChangeTracker.Entries<T>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.IsEnabled = true;
                        entry.Entity.CreatedAt = entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsEnabled = false;
                        break;
                }
            }
        }
    }
}
