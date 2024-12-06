using EventProjectWeb.DTO.Ticket;
using FluentValidation;

namespace EventProjectWeb.Model.Validations.Ticket
{
    public class UpdateTicketRequestValidator : AbstractValidator<UpdateTicketRequestDto>
    {
        public UpdateTicketRequestValidator()
        {
            RuleFor(x => x.TicketType)
               .NotEmpty().WithMessage("The TicketType field cannot be empty.");
        }
    }
}
