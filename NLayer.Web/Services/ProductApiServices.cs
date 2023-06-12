using Microsoft.Identity.Client;
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

        public async Task<List<ProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<ProductWithCategoryDto>>>("Products/GetProductsWithCategory");

            return response.Data;
        }
        public async Task<ProductDto> SaveAsync(ProductDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("Products", dto);

            if (!response.IsSuccessStatusCode)
                return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<ProductDto>>();

            return responseBody.Data;

        }

        public async Task<bool> UpdateAsync(ProductDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync("products",dto);
            return response.IsSuccessStatusCode;

        }
        public async Task<bool> UpdateAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/delete/{id}");

            return response.IsSuccessStatusCode;

        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products/{id}");

            return response.IsSuccessStatusCode;

        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<ProductDto>>($"products/{id}");
            return response.Data;

        }  

    }
}
