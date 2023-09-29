using AutoMapper;
using Domain.Dtos.Admin;
using Domain.Entities.Admin;
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
            await _repository.AddAsync(model);

            product.Id = model.Id;

            return product;
        }

        public async Task<ProductDTO> Update(Guid id, ProductDTO product)
        {
            var model = await _repository.GetByIdAsync(id);

            _mapper.Map(product, model);

            await _repository.UpdateAsync(model);

            return product;
        }

        public async Task<ProductDTO> GetById(Guid id)
        {
            var product = await _repository.GetByIdAsync(id);
            var dto = _mapper.Map<ProductDTO>(product);

            return dto;
        }

        public async Task<IEnumerable<Product>> List() =>
            await _repository.GetAllAsync();

        public async Task<ProductDTO> Delete(Guid id)
        {
            var model = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(model);


            var dto = _mapper.Map<ProductDTO>(model);
            return dto;
        }
    }
}
