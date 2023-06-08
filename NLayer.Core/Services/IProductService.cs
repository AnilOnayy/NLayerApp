﻿using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IProductService  : IService<Product> 
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetWithCategoryAsync(); 
    }
}
