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
        public const string RequiredErrorMessage = "Полето {0} е задължително.";
        public const string StringLengthErrorMessage = "Полето {0}трябва да съдържа между {2} и {1} символа.";
        public const string InvalidDateErrorMessage = $"Невалидна дата. Форматът трябва да е: {DateFormat}.";
        public const string PasswordAndConfirmErrorMessage = "Паролата и потвърждението ѝ трябва да съвпадат.";
        public const string ChooseItemErrorMessage = "Изберете {0}.";



        public const string CurrencyNotExist = "Валутата не съществува!";
        public const string CreditTypeNotExist = "Credit type не съществува!";
        public const string CreditorTypeNotExist = "Creditor type не съществува!";
        public const string DebtTermTypeNotExist = "Debt term type не съществува!";
        public const string DebtPurposeTypeNotExist = "Debt purpose type не съществува!";
        public const string InterestTypeNotExist = "Interest type не съществува!";


        //DateFormat
        public const string DateFormat = "dd-MM-yyyy";  //"dd.MM.yyyy HH:mm";      //yyyy-MM-dd H:mm

        //CurrencyFormat
        public const string CurrencyFormat = "C";

        //Nomenclatures
        public const int NomenclatureNameMaxLength = 100;
        public const int UserMaxLength = 450;
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


        //Register
        public const int UserFirstNameMaxLength = 12;
        public const int UserFirstNameMinLength = 1;
        public const int UserLastNameMaxLength = 15;
        public const int UserLastNameMinLength = 3;
        public const int MinSelectedValue = 1;
        public const int MaxSelectedValue = int.MaxValue;
        

    }
}
