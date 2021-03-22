using FluentValidation;

namespace ContactInterview.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty()
                .WithMessage("FirstName is required.");
            RuleFor(v => v.FirstName)
                .MaximumLength(60)
                    .WithMessage("FirstName must be a maximum of 60 characters.")
                .NotEmpty()
                    .WithMessage("FirstName is required.");
            RuleFor(v => v.SecondName)
                .MaximumLength(60)
                .WithMessage("SecondName must be a maximum of 60 characters.");
            RuleFor(v => v.LastName)
                .MaximumLength(60)
                    .WithMessage("SecondName must be a maximum of 60 characters.")
                .NotEmpty()
                    .WithMessage("LastName is required");
            RuleFor(v => v.SecondLastName)
                .MaximumLength(60)
                    .WithMessage("Second LastName must be a maximum of 60 characters.");
            RuleFor(v => v.Prefix)
                .MaximumLength(60)
                    .WithMessage("Second LastName  must be a maximum of 60 characters.");
            RuleFor(v => v.Suffix)
                .MaximumLength(60)
                    .WithMessage("Suffix must be a maximum of 60 characters.");
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
