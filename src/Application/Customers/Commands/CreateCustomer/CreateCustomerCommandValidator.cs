using FluentValidation;

namespace ContactInterview.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .MaximumLength(60)
                    .WithMessage("FirstName must have a maximum of 60 characters.")
                .NotEmpty()
                    .WithMessage("FirstName is required.");
            RuleFor(v => v.SecondName)
                .MaximumLength(60)
                .WithMessage("SecondName must have a maximum of 60 characters.");
            RuleFor(v => v.LastName)
                .MaximumLength(60)
                    .WithMessage("SecondName must have a maximum of 60 characters.")
                .NotEmpty()
                    .WithMessage("LastName is required");
            RuleFor(v => v.SecondLastName)
                .MaximumLength(60)
                    .WithMessage("Second LastName must have a maximum of 60 characters.");
            RuleFor(v => v.Prefix)
                .MaximumLength(60)
                    .WithMessage("Second LastName  must have a maximum of 60 characters.");
            RuleFor(v => v.Suffix)
                .MaximumLength(60)
                    .WithMessage("Suffix must have a maximum of 60 characters.");
            RuleFor(v => v.IdentificationTypeId)
                .NotEmpty()
                    .WithMessage("Identitifaction Type is required.");
            RuleFor(v => v.IdNumber)
                .NotEmpty()
                    .WithMessage("Id Number is required.");
            RuleFor(v => v.MaritalStatusId)
                .NotEmpty()
                    .WithMessage("Marital status is required.");
            RuleFor( v => v.GenderId)
                .NotEmpty()
                .WithMessage("Gender is required.");
        }
    }
}
