using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures
{
    [Table("EBKs", Schema = "nomenclatures")]
    [Comment("Table for all municipalities in BG with their EBK codes")]
    public class EBK : Nomenclature
    {
    }
}
