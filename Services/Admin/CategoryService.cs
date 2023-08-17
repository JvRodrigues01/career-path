using Domain.Dtos.Admin;
using Domain.Entities.Admin;
using Infra.Repository.Admin.NHibernate;

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

            return await _repository.Create(model);
        }

        public async Task<Category> Update(Guid id, CategoryDTO category)
        {
            var model = await _repository.GetById(id);

            model.Name = category.Name;
            model.Description = category.Description;
            model.IsEnabled = category.IsEnabled;
            model.UpdatedAt = DateTime.Now;

            return await _repository.Update(model);
        }

        public async Task<Category> GetById(Guid id) =>
            await _repository.GetById(id);

        public async Task<IEnumerable<Category>> List() =>
            await _repository.List();

        public async Task<Category> Delete(Guid id)
        {
            var model = await _repository.GetById(id);

            model.IsEnabled = false;

            return await _repository.Update(model);
        }
    }
}
