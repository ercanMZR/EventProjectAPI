using EventProjectWeb.DTO.Ticket;
using FluentValidation;

namespace EventProjectWeb.Model.Validations.Ticket
{
    public class CreateTicketRequestValidator: AbstractValidator<CreateTicketRequestDto>
    {
        public CreateTicketRequestValidator()
        {
            RuleFor(x => x.TicketType)
                .NotEmpty().WithMessage("The TicketType field cannot be empty.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("The Price field cannot be empty.");
        }
    }
}
