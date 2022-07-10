using CustomerSupport.Application.Common.Enums;

namespace CustomerSupport.Application.CustomerInquiry.Dtos
{
    public class CustomerInquiryResultDto
    {
        public string Email { get; set; }

        public string Phone { get; set; }

        public string? Number { get; set; }

        public InquiryTypes InquiryType { get; set; }

        public string Description { get; set; }

        public bool TermsAndCondition { get; set; }
    }
}
