﻿using AutoMapper;
using NLayer.Core.DTOs.CategoryDTOs;
using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.DTOs.ProductFeatureDTOs;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ProductUpdateDto,Product >();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();

        }
    }
}