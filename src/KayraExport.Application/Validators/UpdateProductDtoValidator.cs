using FluentValidation;
using KayraExport.Domain.DTOs;

namespace KayraExport.Application.Validators
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            When(x => x.Name != null, () =>
            {
                RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Product name cannot be empty.")
                    .Length(3, 100).WithMessage("Product name must be between 3 and 100 characters.");
            });

            When(x => x.Description != null, () =>
            {
                RuleFor(x => x.Description)
                    .NotEmpty().WithMessage("Description cannot be empty.")
                    .Length(10, 500).WithMessage("Description must be between 10 and 500 characters.");
            });

            When(x => x.Price.HasValue, () =>
            {
                RuleFor(x => x.Price.Value)
                    .GreaterThan(0).WithMessage("Price must be greater than zero.");
            });

            When(x => x.Stock.HasValue, () =>
            {
                RuleFor(x => x.Stock.Value)
                    .GreaterThanOrEqualTo(0).WithMessage("Stock must be zero or greater.");
            });
        }
    }
}
