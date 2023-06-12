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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Services
{
    public class CategoryServiceWithDto : ServiceWithDto<Category, CategoryDto>, ICategoryServiceWithDto
    {
        private readonly ICategoryRepository _repository;

        public CategoryServiceWithDto(IGenericRepository<Category> genericRepository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository repository) : base(genericRepository, unitOfWork, mapper)
        {
            _repository = repository;
        }

        public async Task<CustomResponseDto<List<CategoryWithProductDto>>> GetCategoriesWithProductsAsync()
        {
           var data =  await _repository.GetCategoriesWithProductsAsync();
            var dataDto = _mapper.Map<List<CategoryWithProductDto>>(data);


            return CustomResponseDto<List<CategoryWithProductDto>>.Success(200,dataDto);
        }
    }
}
