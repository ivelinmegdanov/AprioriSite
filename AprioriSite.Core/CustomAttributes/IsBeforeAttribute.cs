using System.ComponentModel.DataAnnotations;

namespace AprioriSite.Core.CustomAttributes
{
    public class IsBeforeAttribute : ValidationAttribute
    {
        private readonly string propertyToCompare;

        public IsBeforeAttribute(string _propertyToCompare, string ErrorMessage = "")
        {
            propertyToCompare = _propertyToCompare;
            this.ErrorMessage = ErrorMessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                DateTime dateToCompare = (DateTime)validationContext.ObjectType.GetProperty(propertyToCompare).GetValue(validationContext.ObjectInstance);

                if ((DateTime)value < dateToCompare)
                {
                    return ValidationResult.Success;
                }
            }
            catch (Exception ex)
            {
            }

            return new ValidationResult(ErrorMessage);
        }
    }
}
