using EventProjectWeb.DTO.Venue;
using FluentValidation;

namespace EventProjectWeb.Model.Validations.Venue
{
    public class CreateVenueRequestValidator: AbstractValidator<CreateVenueRequestDto>
    {
        public CreateVenueRequestValidator()
        {
            RuleFor(x => x.VenueName)
                 .NotEmpty().WithMessage("Venue Name field cannot be empty.")
                 .MaximumLength(50).WithMessage("Venue Name must be at most 50 characters.");

            RuleFor(x => x.Location)
                .MaximumLength(500).WithMessage("Location must be at most 500 characters.")
                .NotEmpty().WithMessage("Location field cannot be empty.");

            RuleFor(x => x.Capacity)
                 .NotEmpty().WithMessage("Capacity field cannot be empty.");
        }
    }
}
