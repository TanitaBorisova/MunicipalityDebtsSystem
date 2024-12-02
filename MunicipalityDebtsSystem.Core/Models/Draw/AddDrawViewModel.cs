using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Core.Models.Draw
{
    public class AddDrawViewModel
    {
        [Required]
        [Comment("Identifier of the debt")]
        public int? DebtId { get; set; }

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
    }
}
