﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MunicipalityDebtsSystem.Infrastructure.Data.Constants.ValidationConstants;


namespace MunicipalityDebtsSystem.Core.Models.Draw
{
    public class AddDrawViewModel
    {
        [Required]
        public int DebtId { get; set; }

        public int DrawParentId { get; set; }


        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Дата на реално усвояване")]
        public string DrawDate { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = "Размер на планирано усвояване")]
        public decimal DrawAmount { get; set; }

        [Required]
        [Range(4,4)]  //Draw
        public int OperationTypeId { get; set; }


        public string MunicipalityCode { get; set; } = string.Empty;

        [Required]
        public string MunicipalityName { get; set; } = string.Empty;
    }
}