using CustomerSupport.Application.Contracts;
using CustomerSupport.Application.CustomerInquiry.Dtos;
using MediatR;

namespace CustomerSupport.Application.CustomerInquiry.Queries
{
    public class GetCustomerInquiryQueryHandler : IRequestHandler<GetCustomerInquiryQuery, CustomerInquiryResultDto>
    {
        private readonly ICacheService _cacheService;
        public GetCustomerInquiryQueryHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<CustomerInquiryResultDto> Handle(GetCustomerInquiryQuery query, CancellationToken cancellationToken)
        {            
            var result = await _cacheService.GetItemFromCache<CustomerInquiryResultDto>(query.Key);

            return result;
        }
    }
}
