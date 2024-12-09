using MunicipalityDebtsSystem.Core.Contracts;
using MunicipalityDebtsSystem.Core.Models.Municipality;
using MunicipalityDebtsSystem.Infrastructure.Data.Common;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunicipalityDebtsSystem.Core.Models.Common;
using MunicipalityDebtsSystem.Core.Enums;


namespace MunicipalityDebtsSystem.Core.Services
{
    public class CommonService : ICommonService
    {
       
        public List<YearViewModel> GetYears()
        {
            var years = new List<YearViewModel>();

            int startYear = 2020;
            int endYear = 2025;

            for (int i = startYear; i <= endYear; i++)
            {
                years.Add(new YearViewModel
                {
                    Id = i, // Using the year as the ID
                    YearName = i.ToString() // Display the year as a string
                });
            }

            return years;

        }

        public List<MonthViewModel> GetMonths()
        {
            var months = new List<MonthViewModel>();

            foreach (var month in Enum.GetValues(typeof(Month)))
            {
                months.Add(new MonthViewModel
                {
                    Id = (int)month,
                    MonthName = month.ToString()
                });
            }

            return months;
        }


    }
}
