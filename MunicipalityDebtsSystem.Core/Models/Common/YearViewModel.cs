using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Common
{
    public class YearViewModel
    {
        public int Id { get; set; } // Unique identifier
        public string YearName { get; set; } = string.Empty; // Display name for the year
    }
}
