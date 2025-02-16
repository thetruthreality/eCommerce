


using AutoMapper;
using ECommerceAPI.DataBase.Models;
using ECommerceAPI.ViewModels;
using Microsoft.AspNetCore.Identity;

public class MappingProfile : Profile
{
    public MappingProfile(){
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Cart,CartDto>().ReverseMap();
        CreateMap<CartItem,CartItemDto>()
        .ForMember(x => x.ProductName,y=>y.MapFrom(p=>p.Product.Name))
        .ForMember(dest=>dest.Price,opt=>opt.MapFrom(p=>p.Product.Price))
        .ForMember(dest=>dest.ImageUrl,opt=>opt.MapFrom(p=>p.Product.ImageUrl))
        .ForMember(dest=>dest.TotalPrice,opt=>opt.MapFrom(p=>p.Product.Price * p.Quantity));

        CreateMap<IdentityUser,UserInfoDto>();
        
    }
}