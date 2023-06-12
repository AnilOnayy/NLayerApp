using AutoMapper;
using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class ProductServiceWithDto : ServiceWithDto<Product, ProductDto>, IProductServiceWithDto
    {
        private readonly IProductRepository _productRepository;

        public ProductServiceWithDto(IGenericRepository<Product> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(genericRepository, unitOfWork, mapper)
        {
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<NoContentResponseDto>> AddAsync(ProductCreateDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            await _productRepository.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentResponseDto>.Success(201);
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetWithCategoryAsync()
        {
            var data = await _productRepository.GetProductsWithCategoryAsync();
            var dataDto = _mapper.Map <List<ProductWithCategoryDto>> (data);

            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, dataDto);
        }

        public async Task<CustomResponseDto<ProductDto>> Update(ProductUpdateDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            var productDto = _mapper.Map<ProductDto>(dto);
            _productRepository.Update(entity);

            await _unitOfWork.CommitAsync();

            return CustomResponseDto<ProductDto>.Success(204, productDto);
        }
    }
}
