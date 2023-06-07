using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.ResponseDTOs
{
    public class NoContentResponseDto
    {
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public bool isSuccess { get; set; }

        public static NoContentResponseDto Success(int statusCode)
        {
            return new NoContentResponseDto {  StatusCode = statusCode,isSuccess=true };
        }
      

        public static NoContentResponseDto Fail(int statusCode, List<string> errors)
        {
            return new NoContentResponseDto { StatusCode = statusCode, Errors = errors , isSuccess = false };
        }
        public static NoContentResponseDto Fail(int statusCode, string error)
        {
            return new NoContentResponseDto { StatusCode = statusCode, Errors = new List<string> { error }, isSuccess = false};
        }
    }
}
