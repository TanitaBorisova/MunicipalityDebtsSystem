﻿using MunicipalityDebtsSystem.Core.Models.Debt;
using MunicipalityDebtsSystem.Infrastructure.Data.Constants;
using MunicipalityDebtsSystem.Infrastructure.Data.CustomValidations;
using System;
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


        [Required]
        public int DrawParentId { get; set; }

        
        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = ValidationConstants.DrawPlannedAmountName)]
       
        public decimal DrawPlannedAmount { get; set; }


        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = ValidationConstants.DrawDateName)]
        public string DrawDate { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Display(Name = ValidationConstants.DrawAmountName)]
        public decimal DrawAmount { get; set; }

        [Required]
        public int OperationTypeId { get; set; }

        [NotZeroSelection]
        [Display(Name = ValidationConstants.PlannedDrawChooseDate)]
        public int PlannedDrawId { get; set; }

        public bool IsFinished { get; set; }

        public List<PlannedDrawDateViewModel> PlannedDrawDates { get; set; } = new List<PlannedDrawDateViewModel>();

        public DebtPartialInfoViewModel DebtPartialInfo { get; set; } = new DebtPartialInfoViewModel();
    }
}
