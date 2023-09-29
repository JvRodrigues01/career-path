using AutoMapper;
using Domain.Dtos.Admin;
using Domain.Entities.Admin;

namespace Services.AutoMapper
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile() 
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
        }
    }
}
