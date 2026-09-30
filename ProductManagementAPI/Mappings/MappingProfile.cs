using AutoMapper;
using ProductManagementAPI.DTOs;
using ProductManagementAPI.Entities;
using ProductManagementAPI.Features.Products.Commands;

namespace ProductManagementAPI.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>();

        CreateMap<CreateProductDto, Product>();

        CreateMap<UpdateProductDto, Product>();

        CreateMap<CreateProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}   