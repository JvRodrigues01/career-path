using AutoMapper;
using Domain.Dtos.Admin;
using Domain.Entities.Admin;
using Domain.Exceptions;
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

            var result = await _repository.AddAsync(model);

            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<CategoryDTO> Update(Guid id, CategoryDTO category)
        {
            var model = await _repository.GetByIdAsync(id) ?? throw new BadRequestException("Categoria não encontrada");

            _mapper.Map(category, model);

            var result = await _repository.UpdateAsync(model);

            return _mapper.Map<CategoryDTO>(result);
        }

        public async Task<CategoryDTO> GetById(Guid id)
        {
            var model = await _repository.GetByIdAsync(id) ?? throw new BadRequestException("Categoria não encontrada");
            var dto = _mapper.Map<CategoryDTO>(model);

            return dto;
        }

        public async Task<IEnumerable<Category>> List() =>
            await _repository.GetAllAsync();

        public async Task<CategoryDTO> Delete(Guid id)
        {
            var model = await _repository.GetByIdAsync(id) ?? throw new BadRequestException("Categoria não encontrada");
            var result = await _repository.DeleteAsync(model);

            return _mapper.Map<CategoryDTO>(result);
        }
    }
}
