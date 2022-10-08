using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using FluentValidation;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Validation
{
    public class ProductDTOValidator : AbstractValidator<ProductDTO>
    {
        public ProductDTOValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(30).WithMessage("{PropertyName} is required and less than 30 characters");

            //RuleFor(p => p.Description).NotNull().NotEmpty().MaximumLength(200).WithMessage("{PropertyName} is required and less than 200 characters");

            RuleFor(p => p.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater than 0");

            RuleFor(p => p.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater than 0");

            RuleFor(p => p.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be grater than 0");
        }
    }
}
