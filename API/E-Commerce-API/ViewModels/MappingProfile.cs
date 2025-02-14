


using AutoMapper;
using ECommerceAPI.DataBase.Models;
using ECommerceAPI.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile(){
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}