using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class CategoriesController : CustomBaseController
    {


        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetCategoryWithProducts/{id}")]
        public async Task<IActionResult> GetProductsWithCategory(int id)
        {
            return CreateActionResult(await _service.GetCategoryByIdWithProductsAsync(id));
        }

    }
}
