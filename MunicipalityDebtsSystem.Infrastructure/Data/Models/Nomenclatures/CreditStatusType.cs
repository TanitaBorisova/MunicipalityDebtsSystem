using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures
{
    [Table("CreditsStatusesTypes", Schema = "nomenclatures")]
    [Comment("Table for statuses of the credit")]
    public class CreditStatusType : Nomenclature
    {
    }
}
