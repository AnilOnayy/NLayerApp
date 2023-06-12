using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IServiceWithDto<Entity,Dto> where Entity : BaseEntity  where Dto : class 
    {
        Task<CustomResponseDto<Dto>> GetByIdAsync(int id);
        Task<CustomResponseDto<IEnumerable<Dto>>> GetAllAsync();
        CustomResponseDto<IQueryable<Dto>> Where(Expression<Func<Entity, bool>> expression);
        Task<CustomResponseDto<bool>> AnyAsync(Expression<Func<Entity, bool>> expression);
        Task<CustomResponseDto<Dto>> AddAsync(Dto dto);
        Task<CustomResponseDto<IEnumerable<Dto>>> AddRangeAsync(IEnumerable<Dto> dto);
        Task<CustomResponseDto<NoContentResponseDto>> UpdateAsync(Dto dto);
        Task<CustomResponseDto<NoContentResponseDto>> RemoveAsync(int id);
        Task<CustomResponseDto<NoContentResponseDto>> RemoveRangeAsync(IEnumerable<Dto> dto);
    }
}
