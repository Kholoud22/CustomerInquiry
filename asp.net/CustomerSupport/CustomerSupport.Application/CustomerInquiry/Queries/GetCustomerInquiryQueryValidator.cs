using CustomerSupport.Application.Common.Validations;
using FluentValidation;

namespace CustomerSupport.Application.CustomerInquiry.Queries
{
    public class GetCustomerInquiryQueryValidator : AbstractValidator<GetCustomerInquiryQuery>
    {
        public GetCustomerInquiryQueryValidator()
        {
            RuleFor(p => p.Key)
                   .NotEmpty();
        }
    }
}
