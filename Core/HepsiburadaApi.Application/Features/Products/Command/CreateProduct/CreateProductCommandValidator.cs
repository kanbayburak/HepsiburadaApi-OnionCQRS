﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiburadaApi.Application.Features.Products.Command.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithName("Başlık");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithName("Açıklama");

            RuleFor(x => x.BrandId)
                .GreaterThan(0)
                .WithName("Marka");

            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithName("Fİyat");

            RuleFor(x => x.Discount)
                .GreaterThanOrEqualTo(0)
                .WithName("İndirim Oranı");

            RuleFor(x => x.CategoryIds)
                .NotEmpty()
                .Must(categories => categories.Any())
                .WithName("Kategoriler");

        }
    }
}
