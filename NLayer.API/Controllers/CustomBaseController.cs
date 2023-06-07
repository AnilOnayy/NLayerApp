using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs.ResponseDTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {

        public IActionResult CreateActionResult<T>(CustomResponseDto<T> dto)
        {
            if (dto.StatusCode == 204)
                return new ObjectResult(null) { StatusCode = dto.StatusCode };
            else
                return new ObjectResult(dto) { StatusCode = dto.StatusCode };

        }
    }
}
