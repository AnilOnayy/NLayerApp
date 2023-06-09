﻿using FluentValidation;
using NLayer.Core.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Validation
{
    public class ProductDtoValidatior : AbstractValidator<ProductDto>
    {
        public ProductDtoValidatior()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("{PropertyName} is required.")
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(x => x.Price)
                .InclusiveBetween(1, int.MaxValue)
                .WithMessage("{PropertyName} is must be greater than zero.");

            RuleFor(x => x.Stock)
                .InclusiveBetween(1, int.MaxValue)
                .WithMessage("{PropertyName} is must be greater than zero.");

        }
    }
}
