


using AutoMapper;
using ECommerceAPI.DataBase.Models;
using ECommerceAPI.ViewModels;

public class MappingProfile : Profile
{
    public MappingProfile(){
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Cart,CartDto>().ReverseMap();
        CreateMap<CartItem,CartItemDto>().ForMember(x => x.ProductName,y=>y.MapFrom(p=>p.Product.Name));
    }
}