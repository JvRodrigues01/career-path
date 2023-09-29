using Domain.Dtos.Admin;
using Domain.Entities.Admin;

namespace Services.Admin
{
    public interface IProductService
    {
        Task<Product> Create(ProductDTO product);
        Task<Product> GetById(Guid id);
        Task<IEnumerable<Product>> List();
        Task<Product> Update(Guid id, ProductDTO product);
        Task<Product> Delete(Guid id);
    }
}
