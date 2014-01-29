// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticsSearchFormModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Web.Models
{
    #region using directives

    using System;
    using System.ComponentModel.DataAnnotations;

    #endregion

    public class StatisticsSearchFormModel : BaseFormModel
    {
        [Required(ErrorMessage = "End Datum ist erforderlich")]
        [Display(Name = "End Datum")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Start Datum ist erforderlich")]
        [Display(Name = "Start Datum")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
    }
}