using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Entities
{
    [Table("PeriodsLists", Schema = "mundebt")]
    [Comment("Table for storing allowed periods for storing data")]
    public class PeriodList
    {
        [Key]
        [Comment("Identifier of the period")]
        public int Id { get; set; }

        [Required]
        [Comment("Starting date of the period")]
        public DateTime PeriodStart { get; set; }

        [Required]
        [Comment("Ending date of the period")]
        public DateTime PeriodEnd { get; set; }

        [Required]
        [Comment("Month of the period like string")]
        [MaxLength(ValidationConstants.MonthMaxLength)]
        public string MonthName { get; set; } = string.Empty;


        [Required]
        [Comment("Year of the period like string")]
        [MaxLength(ValidationConstants.YearMaxLength)]
        public string YearName { get; set; } = string.Empty;

        [Required]
        [Comment("Month of the period like integer")]
        public int MonthInt { get; set; }

        [Required]
        [Comment("Year of the period like integer")]
        public int YearInt { get; set; }

        [Required]
        [Comment("Identifier of Municipality")]
        public int MunicipalityId { get; set; }

        [Required]
        [Comment("User unlocked the period")]
        [MaxLength(ValidationConstants.UserNameMaxLength)]
        public string UserNameUnlock { get; set; } = string.Empty;

        [Required]
        [Comment("Date that period become unlocked")]
        public DateTime DateUnlock { get; set; }
              

        [Comment("User locked the period")]
        [MaxLength(ValidationConstants.UserNameMaxLength)]
        public string? UserNameLock { get; set; } = string.Empty;

        [Comment("User locked the period")]
        public DateTime? DateLock { get; set; }
               

        [ForeignKey(nameof(MunicipalityId))]
        public Municipality Municipality { get; set; } = null!;




    }
}
