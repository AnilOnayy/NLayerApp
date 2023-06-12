using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.CategoryDTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
   
    public class CategoriesWithDtoController : CustomBaseController
    {
        private readonly ICategoryServiceWithDto _service;

        public CategoriesWithDtoController(ICategoryServiceWithDto service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }

        [HttpGet("GetWithProducts")]
        public async Task<IActionResult> GetWithProducts()
        {
            return CreateActionResult(await _service.GetCategoriesWithProductsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto dto)
        {
            return CreateActionResult(await _service.AddAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto dto)
        {
            return CreateActionResult(await _service.UpdateAsync(dto));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _service.RemoveAsync(id));
        }

    }
}
