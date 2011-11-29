// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventSearchFormModel.cs" company="ip-connect GmbH">
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

    public class EventSearchFormModel : BaseFormModel
    {
        #region - Properties -

        [Range(1900, 2100, ErrorMessageResourceName = "EventActivatedAtYearRangeValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EventActivatedAtRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "EventActivatedAtLabelText", ResourceType = typeof(Messages))]
        public DateTime? ActivatedAt { get; set; }

        [StringLength(255, ErrorMessageResourceName = "EventDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EventDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "EventDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        [Range(1900, 2100, ErrorMessageResourceName = "EventExpiresAtYearRangeValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EventExpiresAtRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "EventExpiresAtLabelText", ResourceType = typeof(Messages))]
        public DateTime? ExpiresAt { get; set; }

        [StringLength(255, ErrorMessageResourceName = "EventTitleStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Display(Name = "EventTitleLabelText", ResourceType = typeof(Messages))]
        public string Title { get; set; }

        #endregion
    }
}
