using Domain.Dtos.Admin;
using Domain.Entities.Admin;

namespace Services.Admin
{
    public interface ICategoryService
    {
        Task<CategoryDTO> Create(CategoryDTO category);
        Task<CategoryDTO> GetById(Guid id);
        Task<CategoryDTO> Update(Guid id, CategoryDTO category);
        Task<CategoryDTO> Delete(Guid id);
        Task<IEnumerable<Category>> List();
    }
}
