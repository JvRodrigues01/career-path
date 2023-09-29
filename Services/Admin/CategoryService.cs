using Domain.Dtos.Admin;
using Domain.Entities.Admin;
using Infra.Repository.Admin;

namespace Services.Admin
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        public CategoryService(IGenericRepository<Category> repository) =>
            _repository = repository;

        public async Task<Category> Create(CategoryDTO category)
        {
            var model = new Category()
            {
                Name = category.Name,
                Description = category.Description,
            };

            return await _repository.AddAsync(model);
        }

        public async Task<Category> Update(Guid id, CategoryDTO category)
        {
            var model = await _repository.GetByIdAsync(id);

            model.Name = category.Name;
            model.Description = category.Description;

            return await _repository.UpdateAsync(model);
        }

        public async Task<Category> GetById(Guid id) =>
            await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Category>> List() =>
            await _repository.GetAllAsync();

        public async Task<Category> Delete(Guid id)
        {
            var model = await _repository.GetByIdAsync(id);

            return await _repository.DeleteAsync(model);
        }
    }
}
