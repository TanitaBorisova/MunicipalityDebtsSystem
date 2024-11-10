using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Constants
{
    public static class ValidationConstants
    {
        public const int NomenclatureNameMaxLength = 100;
        public const int UserMaxLength = 50;


        //Debt 
        //public const int DebtNumberMinLength = 1;
        public const int DebtNumberMaxLength = 30;
        public const int ResolutionNumberMaxLength = 50;
        public const int DebtCurrencyMinLength = 3;
        public const int DebtCurrencyMaxLength = 3;
        public const int DataEBKExactLength = 4;


    }
}
