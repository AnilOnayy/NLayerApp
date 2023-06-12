using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using System.Linq.Expressions;

namespace NLayer.Service.Services
{
    public class ServiceWithDto<Entity, Dto> : IServiceWithDto<Entity, Dto> where Entity : BaseEntity where Dto : class
    {
        private readonly IGenericRepository<Entity> _genericRepository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        public ServiceWithDto(IGenericRepository<Entity> genericRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<Dto>> AddAsync(Dto dto)
        {
            var entity = _mapper.Map<Entity>(dto);

            await _genericRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<Dto>.Success(201,dto);


        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dtos)
        {
            var mappedDto = _mapper.Map<IEnumerable<Entity>>(dtos);

            await _genericRepository.AddRangeAsync(mappedDto);
            await _unitOfWork.CommitAsync();


            return CustomResponseDto<IEnumerable<Dto>>.Success(201, dtos);
        }

        public async Task<CustomResponseDto<bool>> AnyAsync(Expression<Func<Entity, bool>> expression)
        {
            var anyResult =await _genericRepository.AnyAsync(expression);

            return CustomResponseDto<bool>.Success(200, anyResult);
        }

        public async Task<CustomResponseDto<IEnumerable<Dto>>> GetAllAsync()
        {
            var all = _genericRepository.GetAll().AsQueryable();
            var allDto = _mapper.Map<IEnumerable<Dto>>(all);

            return CustomResponseDto<IEnumerable<Dto>>.Success(200, allDto);
        }

        public async Task<CustomResponseDto<Dto>> GetByIdAsync(int id)
        {
            var entity = await _genericRepository.GetByIdAsync(id);
            var entityDto = _mapper.Map<Dto>(entity);

            return CustomResponseDto<Dto>.Success(200, entityDto);
        }

        public async Task<CustomResponseDto<NoContentResponseDto>> RemoveAsync(int id)
        {

            var entity =await  _genericRepository.GetByIdAsync(id);

            _genericRepository.Remove(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentResponseDto>.Success(204);
        }

        public async Task<CustomResponseDto<NoContentResponseDto>> RemoveRangeAsync(IEnumerable<Dto> dtos)
        {
            var entities = _mapper.Map<IEnumerable<Entity>>(dtos);

            _genericRepository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentResponseDto>.Success(204);
        }

        public async Task<CustomResponseDto<NoContentResponseDto>> UpdateAsync(Dto dto)
        {
            var entity = _mapper.Map<Entity>(dto);

            _genericRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return CustomResponseDto<NoContentResponseDto>.Success(204);
        }

        public CustomResponseDto<IQueryable<Dto>> Where(Expression<Func<Entity, bool>> expression)
        {
            var data = _genericRepository.Where(expression);
            var dataDto = _mapper.Map<IQueryable<Dto>>(data);

            return CustomResponseDto<IQueryable<Dto>>.Success(200, dataDto);
        }
    }
}
