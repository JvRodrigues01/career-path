using Domain.Entities.Admin;
using NHibernate;

namespace Infra.Repository.Admin.NHibernate
{
    public class CategoryRepository : IGenericRepository<Category>
    {
        private readonly ISession _session;
        public CategoryRepository(ISession session)
        {
            _session = session;
        }

        public async Task Create(Category category)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(category);
                await transaction.CommitAsync();
            }
            catch (Exception)
            {
                await transaction?.RollbackAsync();
                throw new Exception();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public async Task<Category> GetById(Guid id) =>
            await _session.GetAsync<Category>(id);

        public IEnumerable<Category> List() =>
            _session.Query<Category>().ToList();
        public async Task<Category> Update(Category category)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(category);
                await transaction.CommitAsync();
                return category;
            }
            catch (Exception)
            {
                await transaction?.RollbackAsync();
                throw new Exception();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public async Task<Category> Delete(Guid id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var category = await _session.GetAsync<Category>(id);
                category.IsEnabled = false;
                await _session.UpdateAsync(category);
                await transaction.CommitAsync();
                return category;
            }
            catch (Exception)
            {
                await transaction?.RollbackAsync();
                throw new Exception();
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}
