﻿using AutoMapper;
using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductWithCategoryDto>> GetWithCategoryAsync()
        {
            var products = await _productRepository.GetProductsWithCategoryAsync();
            var productDtos = _mapper.Map<List<ProductWithCategoryDto>>(products);

            return productDtos;

        }
    }
}
