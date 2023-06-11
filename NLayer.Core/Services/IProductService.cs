using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.Entities;

namespace NLayer.Core.Services
{
    public interface IProductService : IService<Product>
    {
        Task<List<ProductWithCategoryDto>> GetWithCategoryAsync();
    }
}
