using CustomerSupport.Application.Common.Enums;
using MediatR;

namespace CustomerSupport.Application.CustomerInquiry.Commands
{
    public class CreateCustomerInquiryCommand : IRequest<string>
    {
        public string Email { get; set; }

        public string Phone { get; set; }

        public string? Number { get; set; }

        public int InquiryType { get; set; }

        public string Description { get; set; }

        public bool TermsAndCondition { get; set; }
    }
}
