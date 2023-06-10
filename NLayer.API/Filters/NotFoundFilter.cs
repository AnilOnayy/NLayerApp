using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NLayer.Core.DTOs.ResponseDTOs;
using NLayer.Core.Entities;
using NLayer.Core.Services;
using System.Net.Security;

namespace NLayer.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {

        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if(idValue==null) // Herhangibir parametre almıyorsan direkt devam et
                await  next.Invoke();


            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id==id);
            

            if(anyEntity)
                await next.Invoke();

            context.Result = new NotFoundObjectResult( CustomResponseDto<NoContentResponseDto>.Fail(404,$"{typeof(T).Name}({id}) not found."));
        }
    }
}
