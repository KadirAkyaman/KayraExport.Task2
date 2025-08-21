using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KayraExport.Domain.DTOs;
using KayraExport.Domain.Entities;

namespace KayraExport.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product mappings
            CreateMap<Product, ProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
    
            // User mappings
            CreateMap<User, UserDto>();
            CreateMap<RegisterUserDto, User>();
        }
    }
}