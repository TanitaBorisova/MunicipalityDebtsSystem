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
        public const string InvalidEmailErrorMessage = "Полето {0} има невалиден формат.";
        public const string StringLengthErrorMessage = "Полето {0}трябва да съдържа между {2} и {1} символа.";
        public const string InvalidDateErrorMessage = $"Невалидна дата. Форматът трябва да е: {DateFormat}.";
        public const string PasswordAndConfirmErrorMessage = "Паролата и потвърждението ѝ трябва да съвпадат.";
        public const string ChooseItemErrorMessage = "Изберете {0}.";
        public const string NotZeroErrorMessage = "Стойността на {0} не може да бъде 0.";
        public const string MinValueErrorMessage = "Минималната стойност на полето е {1}.";

        public const string DebtMinValue = "0,01";
        public const string DecimalMaxValue = "1000000000000,00";

        public const string CurrencyNotExist = "Валутата не съществува!";
        public const string CreditTypeNotExist = "Credit type не съществува!";
        public const string CreditorTypeNotExist = "Creditor type не съществува!";
        public const string DebtTermTypeNotExist = "Debt term type не съществува!";
        public const string DebtPurposeTypeNotExist = "Debt purpose type не съществува!";
        public const string InterestTypeNotExist = "Interest type не съществува!";
        public const string MonthNotExist = "Месецът не съществува!";
        public const string YearNotExist = "Годината не съществува!";

        public const string DisplayDebtNumber = "Номер на договор/анекс";
        public const string DisplayResolutionNumber = "Решение за поемане на дълг";
        public const string DisplayDebtBook = "Дата на договаряне";
        public const string DisplayDateContractFinish = "Крайна дата на дълга";
        public const string DisplayDateRealFinish = "Реална дата на погасяване";
        public const string DisplayCurrencyName = "Валута на дълга";
        public const string DisplayDebtCreditName = "Предназначение";
        public const string DisplayDebtCreditorName = "Тип на кредитора";
        public const string DisplayDebtTermName = "Вид на дълга";
        public const string DisplayDebtPurposeName = "Цел на поемането на дълга";
        public const string DisplayDebtInterestName = "Описание на лихвения процент";
        public const string DebtAmountOriginal  = "Размер на дълга в ориг. валута";
        public const string DebtAmountLocal = "Размер на дълга в местна валута";
        public const string OperationTypeIdErrorMessage = "Невалиден тип на операция";
        


        //DateFormat
        public const string DateFormat = "dd.MM.yyyy"; //"dd-MM-yyyy"; //working one "dd-MM-yyyy  //"dd.MM.yyyy HH:mm";      //yyyy-MM-dd H:mm

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

        //OperationTypes
        public const int Payment = 1;
        public const int PlannedPayment = 2;
        public const int Draw = 3;
        public const int PlannedDraw = 4;

        //PeriodList
        public const int MonthMaxLength = 20;
        public const int YearMaxLength = 10;
        public const int UserNameMaxLength = 50;


    }
}
