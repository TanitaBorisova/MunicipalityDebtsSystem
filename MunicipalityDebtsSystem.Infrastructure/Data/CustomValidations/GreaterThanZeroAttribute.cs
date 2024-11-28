namespace MunicipalityDebtsSystem.Infrastructure.Data.CustomValidations
{
    using System.ComponentModel.DataAnnotations;

    public class GreaterThanZeroAttribute : ValidationAttribute
    {
        private readonly decimal _min;
        public GreaterThanZeroAttribute()
            : base("The value must be greater than 0.")
        {
           
        }

        // Override the IsValid method
        public override bool IsValid(object value)
        {
            if (value is decimal decimalValue)
            {
                // Validate that the decimal value is greater than 0
                return decimalValue > 0;
            }
            return false;
        }

        // Optionally override FormatErrorMessage for custom error message
        public override string FormatErrorMessage(string name)
        {
            return $"Стойността на {name} трябва да бъде по-голяма от 0.";
        }
    }
}
