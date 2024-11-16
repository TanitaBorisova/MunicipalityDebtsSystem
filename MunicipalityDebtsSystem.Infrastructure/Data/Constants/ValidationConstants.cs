using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Constants
{
    public static class ValidationConstants
    {
        //Common
        public const string RequiredErrorMessage = "The field {0} is required";
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters length";
        public const string InvalidDateErrorMessage = $"Invalid date! Format must be: {DateFormat}";
        public const string CategoryNotExist = "Category does not exist!";


        //DateFormat
        public const string DateFormat = "dd-MM-yyyy";  //"dd.MM.yyyy HH:mm";      //yyyy-MM-dd H:mm

        //Nomenclatures
        public const int NomenclatureNameMaxLength = 100;
        public const int UserMaxLength = 50;
        public const int MunicipalCenterCodeMaxLength = 2;
        public const int MunicipaliryCodeMaxLength = 4;
        public const int CurrencyCodeMaxLength = 3;
        public const int CurrencyMinValue = 1;


        //Debt 
        public const int DebtNumberMinLength = 1;
        public const int DebtNumberMaxLength = 30;
        public const int ResolutionNumberMinLength = 5;
        public const int ResolutionNumberMaxLength = 50;
        public const int DebtCurrencyMinLength = 3;
        public const int DebtCurrencyMaxLength = 3;
        public const int DataEBKExactLength = 4;


    }
}
