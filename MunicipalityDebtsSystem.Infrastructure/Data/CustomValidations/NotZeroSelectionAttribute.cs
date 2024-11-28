using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.CustomValidations
{
    public class NotZeroSelectionAttribute : ValidationAttribute
    {
        public NotZeroSelectionAttribute()
            : base("Изберете стойност.")
        {
        }

        // Override the IsValid method
        public override bool IsValid(object value)
        {
            // Ensure the value is not "0"
            if (value is string stringValue)
            {
                return stringValue != "0";
            }
            if (value is int intValue)
            {
                return intValue != 0;
            }
            return true; // If it's not a string or is null, it's valid (you can adjust this if necessary)
        }

        // Optionally override FormatErrorMessage for custom error message
        public override string FormatErrorMessage(string name)
        {
            return $"Изберете {name}.";
        }
    }
}
