using AutoMapper;
using NLayer.Core.DTOs.CategoryDTOs;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepisotry,IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepisotry;
            _mapper = mapper;
        }

       

        public async Task<CustomResponseDto<CategoryWithProductDto>> GetCategoryByIdWithProductsAsync(int id)
        {
            var products = await _categoryRepository.GetCategoryByIdWithProductsAsync(id);
            var productDtos = _mapper.Map <CategoryWithProductDto> (products);

            return CustomResponseDto<CategoryWithProductDto>.Success(200, productDtos);
        }
    }
}
