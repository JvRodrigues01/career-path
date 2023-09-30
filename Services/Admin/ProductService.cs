using AutoMapper;
using Domain.Dtos.Admin;
using Domain.Entities.Admin;
using Domain.Exceptions;
using Infra.Repository.Admin;

namespace Services.Admin
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> Create(ProductDTO product)
        {
            var model = _mapper.Map<Product>(product);
            var result = await _repository.AddAsync(model);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> Update(Guid id, ProductDTO product)
        {
            var model = await _repository.GetByIdAsync(id) ?? throw new BadRequestException("Produto não encontrado");

            _mapper.Map(product, model);

            var result = await _repository.UpdateAsync(model);

            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            var product = await _repository.GetByIdAsync(id) ?? throw new BadRequestException("Produto não encontrado");
            var dto = _mapper.Map<ProductDTO>(product);

            return dto;
        }

        public async Task<IEnumerable<Product>> List() =>
            await _repository.GetAllAsync();

        public async Task<ProductDTO> Delete(Guid id)
        {
            var model = await _repository.GetByIdAsync(id) ?? throw new BadRequestException("Produto não encontrado");
            var result = await _repository.DeleteAsync(model);

            return _mapper.Map<ProductDTO>(result);
        }
    }
}
