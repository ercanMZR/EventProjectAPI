using EventProjectWeb.DTO.Event;
using FluentValidation;

namespace EventProjectWeb.Model.Validations.Event
{
    public class UpdateEventRequestValidator: AbstractValidator<UpdateEventRequestDto>
    {
        public UpdateEventRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("The Name field cannot be empty.")
                .MaximumLength(20).WithMessage("Name must be at most 20 characters.");
        }
    }
}
