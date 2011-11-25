// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuSearchFormModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models
{
    #region using directives

    using System;
    using System.ComponentModel.DataAnnotations;

    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Domain.Validators;

    #endregion

    public class MenuSearchFormModel : BaseFormModel
    {
        #region - Properties -

        [Range(1900, 2100, ErrorMessageResourceName = "MenuDateYearRangeValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "MenuDateRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "MenuDateLabelText", ResourceType = typeof(Messages))]
        public DateTime? Date { get; set; }

        [StringLength(255, ErrorMessageResourceName = "MenuDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "MenuDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "MenuDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        #endregion
    }
}
