using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDTO>().ReverseMap();
            CreateMap<ProductUpdateDTO, ProductDTO>();
        }
    }
}
