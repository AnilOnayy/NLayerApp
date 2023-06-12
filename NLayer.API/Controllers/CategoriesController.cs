using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.CategoryDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    public class CategoriesController : CustomBaseController
    {


        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("GetCategoryWithProducts/{id}")]
        public async Task<IActionResult> GetProductsWithCategory(int id)
        {
            return CreateActionResult(await _service.GetCategoryByIdWithProductsAsync(id));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories = await _service.GetAllAsync();
            categories = categories.ToList();

            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories);

            var x = "123";

            return CreateActionResult( CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDto) );

        }

    }       

}
