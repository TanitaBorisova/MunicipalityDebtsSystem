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

    [Table("Draws", Schema = "mundebt")]
    [Comment("Table for storing draws of the debt")]
    public class Draw
    {
        [Key]
        [Comment("Identifier of the draw")]
        public int Id { get; set; }

        [Required]
        [Comment("Identifier of the debt")]
        public int DebtId { get; set; }

        [Required]
        [Comment("Identifier of the parent draw - populated for real draw")]
        public int? DrawParentId { get; set; }

        [Required]
        [Comment("Date of the draw")]
        public DateTime DrawDate { get; set; }

        [Required]
        [Comment("Amount of the draw")]
        public decimal DrawAmount { get; set; }

        [Required]
        [Comment("Identifier of the debt")]
        public int OperationTypeId { get; set; }

        [Required]
        [Comment("Identifier of Municipality")]
        public int MunicipalityId { get; set; }

        [Required]
        [Comment("User created the draw")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string UserCreated { get; set; } = string.Empty;

        [Required]
        [Comment("Date creation of the draw")]
        public DateTime DateCreated { get; set; }

        [Comment("User modified the draw")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string? UserModified { get; set; }

        [Comment("Date of modification of the draw")]
        public DateTime? DateModified { get; set; }

        [Comment("User marked the draw as deleted")]
        [MaxLength(ValidationConstants.UserMaxLength)]
        public string? UserDeleted { get; set; }

        [Comment("Date of deletion of the draw")]
        public DateTime? DateDeleted { get; set; }

        [Required]
        [Comment("Shows if the draw is marked as deleted")]
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(MunicipalityId))]
        public Municipality Municipality { get; set; } = null!;

        [ForeignKey(nameof(DebtId))]
        public Debt Debt { get; set; } = null!;

        public Draw ParentDraw { get; set; } = null!;

        public ICollection<Draw> ChildDraws { get; set; } = null!; // Children


    }
}
