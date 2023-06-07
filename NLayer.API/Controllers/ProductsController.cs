using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        public ProductsController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return Ok(CustomResponseDto<List<ProductDto>>.Success(200, productDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return Ok(CustomResponseDto<ProductDto>.Success(200, productDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductDto p)
        {
            var product = _mapper.Map<Product>(p);
            await _service.AddAsync(product);
            return Ok(CustomResponseDto<ProductDto>.Success(201, p));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto p)
        {
            var product = _mapper.Map<Product>(p);
            await _service.UpdateAsync(product);

            return Ok(NoContentResponseDto.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
                
            return Ok(NoContentResponseDto.Success(204));
        }
    }
}
