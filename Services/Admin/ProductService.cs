using Domain.Dtos.Admin;
using Domain.Entities.Admin;
using Infra.Repository.Admin;

namespace Services.Admin
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _repository;
        public ProductService(IGenericRepository<Product> repository) =>
            _repository = repository;

        public async Task<Product> Create(ProductDTO product)
        {
            var model = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                IdCategory = product.IdCategory,
                Price = product.Price,
                StockQuantity = product.StockQuantity,
            };

            return await _repository.AddAsync(model);
        }

        public async Task<Product> Update(Guid id, ProductDTO product)
        {
            var model = await _repository.GetByIdAsync(id);

            model.Name = product.Name;
            model.Description = product.Description;
            model.IdCategory = product.IdCategory;
            model.Price = product.Price;
            model.StockQuantity = product.StockQuantity;

            return await _repository.UpdateAsync(model);
        }

        public async Task<Product> GetById(Guid id) =>
            await _repository.GetByIdAsync(id);

        public async Task<IEnumerable<Product>> List() =>
            await _repository.GetAllAsync();

        public async Task<Product> Delete(Guid id)
        {
            var model = await _repository.GetByIdAsync(id);
            return await _repository.DeleteAsync(model);
        }
    }
}
