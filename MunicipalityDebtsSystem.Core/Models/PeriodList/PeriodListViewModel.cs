using MunicipalityDebtsSystem.Core.Models.Municipality;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System.ComponentModel.DataAnnotations;

namespace MunicipalityDebtsSystem.Core.Models.PeriodList
{
    public class PeriodListViewModel
    {
        public int Id { get; set; }
        public string MonthName { get; set; } = string.Empty;

        public string YearName { get; set; } = string.Empty;

        public int MunicipalityId { get; set; }

        public string MunicipalityCode { get; set; } = string.Empty;

        public string MunicipalityName { get; set; } = string.Empty;

        public string UserUnlocked { get; set; } = string.Empty;

        public string DateUnlocked { get; set; } = string.Empty;

        public List<MunicipalityViewModel> Municipalities { get; set; } = new List<MunicipalityViewModel>();



        public bool IsUnlock { get; set; }
    }
}
