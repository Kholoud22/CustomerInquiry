using CustomerSupport.Application.Common.Validations;
using FluentValidation;

namespace CustomerSupport.Application.CustomerInquiry.Commands
{
    public class CreateCustomerInquiryCommandValidator : AbstractValidator<CreateCustomerInquiryCommand>
    {
        public CreateCustomerInquiryCommandValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailFormat();

            RuleFor(p => p.Phone)
                   .NotEmpty()
                   .PhoneFormat();

            RuleFor(p => p.Description)
                   .NotEmpty();

            RuleFor(p => p.InquiryType)
                   .NotEmpty();

            RuleFor(p => p.TermsAndCondition)
                   .NotEmpty()
                   .Equal(true);
        }
    }
}
