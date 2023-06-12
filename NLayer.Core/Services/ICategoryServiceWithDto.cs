using NLayer.Core.DTOs.CategoryDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface ICategoryServiceWithDto : IServiceWithDto<Category,CategoryDto>
    {
        Task<CustomResponseDto<List<CategoryWithProductDto>>> GetCategoriesWithProductsAsync();

    }
}
