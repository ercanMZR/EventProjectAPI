using EventProjectWeb.DTO.Customer;
using FluentValidation;

namespace EventProjectWeb.Model.Validations.Artist
{
    public class UpdateCustomerRequestValidator : AbstractValidator<UpdateCustomerRequestDTO>
    {
        public UpdateCustomerRequestValidator()
        {
            RuleFor(x => x.CustomerName)
                 .NotEmpty().WithMessage("Customer Name field cannot be empty.")
                 .MaximumLength(50).WithMessage("Customer Name must be at most 50 characters.");

            RuleFor(x => x.Email)
                .MaximumLength(500).WithMessage("Email must be at most 500 characters.");

            RuleFor(x => x.Address)
                .MaximumLength(200).WithMessage("Address must be at most 500 characters.");
        }
    }
}
