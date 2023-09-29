using AutoMapper;
using Domain.Dtos.Admin;
using Domain.Entities.Admin;
using Infra.Repository.Admin;

namespace Services.Admin
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryDTO> Create(CategoryDTO category)
        {
            var model = _mapper.Map<Category>(category);
            await _repository.AddAsync(model);

            category.Id = model.Id;
            return category;
        }

        public async Task<CategoryDTO> Update(Guid id, CategoryDTO category)
        {
            var model = await _repository.GetByIdAsync(id);

            _mapper.Map(category, model);

            await _repository.UpdateAsync(model);
            
            return category;
        }

        public async Task<CategoryDTO> GetById(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);
            var dto = _mapper.Map<CategoryDTO>(category);

            return dto;
        }

        public async Task<IEnumerable<Category>> List() =>
            await _repository.GetAllAsync();

        public async Task<CategoryDTO> Delete(Guid id)
        {
            var model = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(model);

            var dto = _mapper.Map<CategoryDTO>(model);
            return dto;
        }
    }
}
