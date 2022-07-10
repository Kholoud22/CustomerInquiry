using CustomerSupport.Application.Common.Enums;
using CustomerSupport.Application.CustomerInquiry.Commands;
using CustomerSupport.Application.CustomerInquiry.Queries;
using FluentAssertions;
using System.Threading.Tasks;
using Xunit;

namespace CustomerSupport.Test.Integration
{
    public class CreateCustomerInquiryCommandTest : ApplicationTestBase
    {
        public CreateCustomerInquiryCommandTest()
        {
        }

        [Fact]
        public async Task ShouldCreateNewInquiry()
        {
            CreateCustomerInquiryCommand command = new CreateCustomerInquiryCommand()
            {
                Description = "I would like to ask about the opening dates",
                Email = "kholoud@yahoo.com",
                InquiryType = (int)InquiryTypes.General,
                Number = "AB123",
                Phone = "+201234567896",
                TermsAndCondition = true
            };
            var requestKey = await SendAsync(command);

            requestKey.Should().NotBeEmpty();

            string key = $"inquiry-{command.Email}-{command.Phone}";

            var inquiry = await SendAsync(new GetCustomerInquiryQuery()
            {
                Key = key
            });

            inquiry.Description.Should().BeEquivalentTo(command.Description);
            inquiry.Phone.Should().BeEquivalentTo(command.Phone);
            inquiry.Number.Should().BeEquivalentTo(command.Number);
            inquiry.Email.Should().BeEquivalentTo(command.Email);
            inquiry.TermsAndCondition.Should().Be(command.TermsAndCondition);
            inquiry.InquiryType.Should().Be((InquiryTypes)command.InquiryType);
        }
    }
}
