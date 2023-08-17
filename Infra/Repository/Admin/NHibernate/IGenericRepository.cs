namespace Infra.Repository.Admin.NHibernate
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Create(T item);
        Task<T> GetById(Guid id);
        Task<T> Update(T item);
        Task<T> Delete(Guid id);
        Task<IEnumerable<T>> List();
    }
}
