using System.ComponentModel.DataAnnotations;

namespace WitsWay.Utilities.Validate.Annotations
{
    /// <summary>
    /// 
    /// </summary>
    public class EnumRequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && !"0".Equals(value.ToString());
        }
    }
}
