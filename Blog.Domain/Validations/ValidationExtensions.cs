using FluentValidation;
using FluentValidation.Validators;

namespace Blog.Domain.Validation
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<TClass, TProperty> NotNullOrEmpty<TClass, TProperty>(this IRuleBuilder<TClass, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new NotNullOrEmptyValidator<TClass, TProperty>());
        }
    }

    public class NotNullOrEmptyValidator<TClass, TProperty> : PropertyValidator<TClass, TProperty>, INotNullOrEmptyValidator
    {
        public override string Name => "NotNullOrEmptyValidator";

        public override bool IsValid(ValidationContext<TClass> context, TProperty value)
        {
            return !string.IsNullOrEmpty(value?.ToString());
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return Localized(errorCode, Name);
        }
    }

    public interface INotNullOrEmptyValidator : IPropertyValidator { }
}
