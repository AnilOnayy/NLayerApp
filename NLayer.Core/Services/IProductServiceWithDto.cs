using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IProductServiceWithDto : IServiceWithDto<Product,ProductDto>
    {
        Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetWithCategoryAsync();
        Task<CustomResponseDto<NoContentResponseDto>> AddAsync(ProductCreateDto dto);
        Task<CustomResponseDto<ProductDto>> Update(ProductUpdateDto dto);
    }
}
