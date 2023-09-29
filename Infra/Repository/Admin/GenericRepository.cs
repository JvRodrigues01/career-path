using Domain.Entities.Inheritance;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infra.Repository.Admin
{
    public class GenericRepository<T> : IGenericRepository<T> where T : EntityBase
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
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
