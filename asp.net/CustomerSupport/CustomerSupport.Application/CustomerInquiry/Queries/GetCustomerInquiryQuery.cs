using CustomerSupport.Application.Common.Enums;
using CustomerSupport.Application.CustomerInquiry.Dtos;
using MediatR;

namespace CustomerSupport.Application.CustomerInquiry.Queries
{
    public class GetCustomerInquiryQuery : IRequest<CustomerInquiryResultDto>
    {
        public string Key { get; set; }
    }
}
