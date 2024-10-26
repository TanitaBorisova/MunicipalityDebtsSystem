using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures
{

    [Table("DebtsPurposesTypes", Schema = "nomenclatures")]
    [Comment("Table for purpose of the debt")]
    public class DebtPurposeType : Nomenclature
    {
      [Comment("Identificator of debt type")]
      public int DebtTypeId { get; set; }

      [ForeignKey(nameof(DebtTypeId))]
      public DebtType DebtType { get; set; } = null!;

    }
}
