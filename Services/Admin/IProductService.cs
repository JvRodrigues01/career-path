using Domain.Dtos.Admin;
using Domain.Entities.Admin;

namespace Services.Admin
{
    public interface IProductService
    {
        Task<ProductDTO> Create(ProductDTO product);
        Task<ProductDTO> GetById(Guid id);
        Task<ProductDTO> Update(Guid id, ProductDTO product);
        Task<IEnumerable<Product>> List();
        Task<ProductDTO> Delete(Guid id);
    }
}
