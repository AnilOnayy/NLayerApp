using NLayer.Core.DTOs.CategoryDTOs;

namespace NLayer.Core.DTOs.ProductDTOs
{
    public class ProductWithCategoryDto : ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
