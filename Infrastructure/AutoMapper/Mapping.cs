using API_Entry.DTO;
using API_Entry.Models.Concrete;
using AutoMapper;

namespace API_Entry.Infrastructure.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping() 
        { 
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, UpdateProductDTO>().ReverseMap();
        }
    }
}
