using NLayer.Core.DTOs.ProductDTOs;

namespace NLayer.Core.DTOs.CategoryDTOs
{
    public class CategoryWithProductDto : CategoryDto
    {
        public List<ProductDto> Products { get; set; }
    }
}
