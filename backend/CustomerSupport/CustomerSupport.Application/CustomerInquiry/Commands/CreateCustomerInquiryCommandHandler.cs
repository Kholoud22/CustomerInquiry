using CustomerSupport.Application.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CustomerSupport.Application.CustomerInquiry.Commands
{
    public class CreateCustomerInquiryCommandHandler : IRequestHandler<CreateCustomerInquiryCommand, string>
    {
        private readonly ICacheService _cacheService;

        public CreateCustomerInquiryCommandHandler(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task<string> Handle(CreateCustomerInquiryCommand command, CancellationToken cancellationToken)
        {
            string key = $"inquiry-{command.Email}-{command.Phone}";

            var request = await _cacheService.GetItemFromCache<CreateCustomerInquiryCommand>(key);

            if (request is null)
            {
                var isSaved = await _cacheService.SaveItemToCache(key, command);
                if (!isSaved)
                    throw new InvalidOperationException("Can't be saved pls try again");

                return key;
            }

            throw new InvalidOperationException("A request already submitted");
        }
    }
}
