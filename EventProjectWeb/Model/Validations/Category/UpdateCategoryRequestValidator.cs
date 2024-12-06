using EventProjectWeb.DTO.Category;
using FluentValidation;

namespace EventProjectWeb.Model.Validations.Category
{
    public class UpdateCategoryRequestValidator :AbstractValidator<UpdateCategoryRequestDto>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("The Name field cannot be empty.");
               
        }
    }
}
