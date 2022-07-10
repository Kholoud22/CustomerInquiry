using CustomerSupport.Application.Common.Enums;
using CustomerSupport.Application.CustomerInquiry.Commands;
using FluentValidation.TestHelper;
using Xunit;

namespace CustomerSupport.Test.Unit
{
    public class CreateCustomerInquiryCommandValidatorTest
    {
        private readonly CreateCustomerInquiryCommandValidator _validator;
        private readonly CreateCustomerInquiryCommand _command;

        public CreateCustomerInquiryCommandValidatorTest()
        {
            _validator = new CreateCustomerInquiryCommandValidator();
            _command = new CreateCustomerInquiryCommand()
            {
                Description = "I would like to ask about the opening dates",
                Email = "khlood@yahoo.com",
                InquiryType = (int)InquiryTypes.General,
                Number = "AB123",
                Phone = "+201234567896",
                TermsAndCondition = true
            };
        }

        [Fact]
        public void ShouldPass()
        {
            var result = _validator.TestValidate(_command);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void ShouldNotAcceptEmailEmpty()
        {
            _command.Email = string.Empty;
            var result = _validator.TestValidate(_command);

            result.ShouldHaveValidationErrorFor(p => p.Email);
        }

        [Fact]
        public void ShouldNotAcceptPhoneEmpty()
        {
            _command.Phone = string.Empty;
            var result = _validator.TestValidate(_command);

            result.ShouldHaveValidationErrorFor(p => p.Phone);
        }

        [Fact]
        public void ShouldNotAcceptDescriptionEmpty()
        {
            _command.Description = string.Empty;
            var result = _validator.TestValidate(_command);

            result.ShouldHaveValidationErrorFor(p => p.Description);
        }

        [Fact]
        public void ShouldNotAcceptTCFalse()
        {
            _command.TermsAndCondition = false;
            var result = _validator.TestValidate(_command);

            result.ShouldHaveValidationErrorFor(p => p.TermsAndCondition);
        }

        [Fact]
        public void ShouldNotAcceptPhoneFormat()
        {
            _command.Phone = "01110457321";
            var result = _validator.TestValidate(_command);

            result.ShouldHaveValidationErrorFor(p => p.Phone);
        }

        [Fact]
        public void ShouldNotAcceptEmailFormat()
        {
            _command.Email = "khlood_mohamed";
            var result = _validator.TestValidate(_command);

            result.ShouldHaveValidationErrorFor(p => p.Email);
        }
    }
}