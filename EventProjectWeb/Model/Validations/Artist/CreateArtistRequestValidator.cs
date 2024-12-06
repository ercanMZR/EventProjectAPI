using EventProjectWeb.DTO.Artist;
using FluentValidation;

namespace EventProjectWeb.Model.Validations.Artist
{
    public class CreateArtistRequestValidator : AbstractValidator<CreateArtistRequestDTO>
    {
        public CreateArtistRequestValidator()
        {
            RuleFor(x => x.ArtistName)
                .NotEmpty().WithMessage("The ArtistName field cannot be empty.")
                .MaximumLength(50).WithMessage("ArtistName must be at most 50 characters.");

        }
    }
}
