using Domain.Dtos.Admin;
using Domain.Entities.Admin;

namespace Services.Admin
{
    public interface ICategoryService
    {
        Task<Category> Create(CategoryDTO category);
        Task<Category> GetById(Guid id);
        Task<Category> Update(Guid id, CategoryDTO category);
        Task<Category> Delete(Guid id);
        Task<IEnumerable<Category>> List();
    }
}
