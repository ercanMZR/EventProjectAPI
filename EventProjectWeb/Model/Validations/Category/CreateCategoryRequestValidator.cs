using FluentValidation;
using EventProjectWeb.DTO.Category;

namespace EventProjectWeb.Model.Validations.Category
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequestDTO>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("The CategoryName field cannot be empty.")
               .MaximumLength(50).WithMessage("CategoryName must be at most 50 characters.");

        }
    }
}
