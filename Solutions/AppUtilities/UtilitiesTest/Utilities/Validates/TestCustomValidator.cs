using System.ComponentModel.DataAnnotations;
using WitsWay.Utilities.Validate.Annotations;

namespace WitsWay.Utlities.Tests.Utilities.Validates
{
    public class TestCustomValidator : ICustomValidator
    {
        public string Key
        {
            get
            {
                return CustomValidatorKeys.TestCustomValidator;
            }
        }

        public ValidationResult Validate(object val, ValidationContext context)
        {
            //var model = context.ObjectInstance;
            var str = val.ToString();
            var isValid = str == "string2";
            return isValid ? ValidationResult.Success : new ValidationResult("自定义验证不通过");
        }
    }

    public class CustomValidatorKeys
    {
        public const string TestCustomValidator = "TestCustomValidator";
    }
}
