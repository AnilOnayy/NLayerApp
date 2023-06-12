using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NLayer.Web.Services
{
    public class ProductApiServices
    {
        private readonly HttpClient _httpClient;

        public ProductApiServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductWithCategoryDto>> GetProductWithCategory()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("Products/ProductsWithCategoryDto");

            return response.Data;
        }

    }
}
