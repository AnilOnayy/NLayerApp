using NLayer.Core.DTOs.CategoryDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;


namespace NLayer.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<CustomResponseDto<CategoryWithProductDto>> GetCategoryByIdWithProductsAsync(int id);

        List<CategoryDto> GetCategoryDtos();

    }
}
