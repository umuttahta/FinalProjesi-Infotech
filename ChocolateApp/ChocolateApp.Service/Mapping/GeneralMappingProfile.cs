using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChocolateApp.Shared.Dtos;
using ChocolateApp.Entity.Concrete;


namespace ChocolateApp.Service.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, EditCategoryDto>().ReverseMap();

            CreateMap<Chocolate, ChocolateDto>()
                .ForMember(
                    bdto => bdto.Categories,
                    options => options.MapFrom(b => b.ChocolateCategories.Select(bc => bc.Category))
                )
                .ReverseMap();

            CreateMap<Chocolate, AddChocolateDto>().ReverseMap();
            CreateMap<Chocolate, EditChocolateDto>().ReverseMap();
           
           // Cart Mappings
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();

            // Order Mappings
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();

            //.ForMember(abdto => abdto.CategoryIds, options =>
            //    options.MapFrom(b =>
            //        b.ChocolateCategories.Select(bc => bc.Category.Id)))
        }
    }
}
