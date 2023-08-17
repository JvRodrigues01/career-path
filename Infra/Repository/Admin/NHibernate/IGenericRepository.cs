namespace Infra.Repository.Admin.NHibernate
{
    public interface IGenericRepository<T> where T : class
    {
        Task Create(T item);
        Task<T> GetById(Guid id);
        Task<T> Update(T item);
        Task<T> Delete(Guid id);
        IEnumerable<T> List();
    }
}
