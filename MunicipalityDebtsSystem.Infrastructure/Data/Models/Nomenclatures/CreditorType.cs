using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures
{
    [Table("CreditorsTypes", Schema = "nomenclatures")]
    [Comment("Table for creditor's types")]
    public class CreditorType : Nomenclature
    {

    }
}
