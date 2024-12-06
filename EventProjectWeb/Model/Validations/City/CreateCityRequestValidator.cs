using EventProjectWeb.DTO.City;
using FluentValidation;

namespace EventProjectWeb.Model.Validations.Artist
{
    public class CreateCityRequestValidator : AbstractValidator<CreateCityRequestDTO>
    {
        public CreateCityRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The Name field cannot be empty.");
                
        }
    }
}
