using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
  
    public class ProductsWithDtoController : CustomBaseController
    {
        private readonly IProductServiceWithDto _service;

        public ProductsWithDtoController(IProductServiceWithDto service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            return CreateActionResult(await _service.GetAllAsync());
        }




        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _service.GetWithCategoryAsync());
        }

    


        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateActionResult(await _service.GetByIdAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductDto p)
        {
            return CreateActionResult(await _service.AddAsync(p));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto p)
        {
            return CreateActionResult(await _service.Update(p));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return CreateActionResult(await _service.RemoveAsync(id));
        }
    }
}
