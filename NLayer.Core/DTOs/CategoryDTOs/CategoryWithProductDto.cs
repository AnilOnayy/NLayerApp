using NLayer.Core.DTOs.ProductDTOs;
using NLayer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs.CategoryDTOs
{
    public class CategoryWithProductDto : CategoryDto
    {
        public List<ProductDto> Products{ get; set; }
    }
}
