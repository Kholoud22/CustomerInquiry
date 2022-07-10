using FluentValidation;

namespace CustomerSupport.Application.Common.Validations
{
    public static class Validators
    {
        private const string EmailRegex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,7})+)$";
        public const string PhoneRegex = @"^\+(?:[0-9]●?){6,14}[0-9]$";

        public static IRuleBuilderOptions<T, string> EmailFormat<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var regex = EmailRegex;
            var message = "'Email' Format is not valid";
            return ruleBuilder.Matches(regex).WithMessage(message);
        }

        public static IRuleBuilderOptions<T, string> PhoneFormat<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var regex = PhoneRegex;
            var message = "'Phone' Format is not valid";
            return ruleBuilder.Matches(regex).WithMessage(message);
        }
    }
}

