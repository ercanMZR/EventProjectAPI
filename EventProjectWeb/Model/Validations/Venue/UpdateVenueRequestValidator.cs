using EventProjectWeb.DTO.Venue;
using FluentValidation;

namespace EventProjectWeb.Model.Validations.Venue
{
    public class UpdateVenueRequestValidator: AbstractValidator<UpdateVenueRequestDto>
    {
        public UpdateVenueRequestValidator()
        {
            RuleFor(x => x.VenueName)
               .NotEmpty().WithMessage("Venue Name field cannot be empty.")
               .MaximumLength(50).WithMessage("Venue Name must be at most 50 characters.");
        }
    }
}
