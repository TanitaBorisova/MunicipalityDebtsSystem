﻿using Microsoft.EntityFrameworkCore;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityDebtsSystem.Infrastructure.Data.Models.Nomenclatures
{
    [Table("Currencies", Schema = "nomenclatures")]
    [Comment("Table for currency")]
    public class Currency : Nomenclature
    {
       
        [MaxLength(ValidationConstants.CurrencyCodeMaxLength)]
        public string CurrencyCode { get; set; } = string.Empty;
    }
}
