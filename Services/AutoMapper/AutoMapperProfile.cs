using AutoMapper;
using Domain.Dtos.Admin;
using Domain.Entities.Admin;

namespace Services.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDTO, Product>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
