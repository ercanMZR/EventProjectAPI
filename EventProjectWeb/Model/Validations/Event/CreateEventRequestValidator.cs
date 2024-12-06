using EventProjectWeb.DTO.Event;
using FluentValidation;

namespace EventProjectWeb.Model.Validations.Event
{
    public class CreateEventRequestValidator: AbstractValidator<CreateEventRequestDto>
    {
        public CreateEventRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The Name field cannot be empty.")
                .MaximumLength(20).WithMessage("Name must be at most 20 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("The Address field cannot be empty.");

            RuleFor(x => x.DetailedDescription)
                .NotEmpty().WithMessage("The Detailed Description field cannot be empty.");
        }
    }
}
