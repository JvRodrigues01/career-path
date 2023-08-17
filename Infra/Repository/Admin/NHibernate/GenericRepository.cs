using NHibernate;

namespace Infra.Repository.Admin.NHibernate
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ISession _session;
        public GenericRepository(ISession session)
        {
            _session = session;
        }

        public async Task<T> Create(T item)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(item);
                await transaction.CommitAsync();
                return item;
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

        public async Task<T> GetById(Guid id) =>
            await _session.GetAsync<T>(id);

        public async Task<IEnumerable<T>> List() => 
            _session.Query<T>().ToList();

        public async Task<T> Update(T item)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(item);
                await transaction.CommitAsync();
                return item;
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

        public async Task<T> Delete(Guid id)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var item = await _session.GetAsync<T>(id);
                await _session.DeleteAsync(item);
                await transaction.CommitAsync();
                return item;
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
