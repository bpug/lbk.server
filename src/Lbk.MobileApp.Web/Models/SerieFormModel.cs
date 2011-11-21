// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerieFormModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models
{
    #region using directives

    using System;
    using System.ComponentModel.DataAnnotations;

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Domain.Validators;

    #endregion

    public class SerieFormModel : BaseFormModel, ICreateSerieCommand
    {
        #region - Properties -

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "SerieActivatedAtRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "SerieActivatedAtLabelText", ResourceType = typeof(Messages))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ActivatedAt { get; set; }

        [StringLength(255, ErrorMessageResourceName = "SerieDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "SerieDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "SerieDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "SerieExpiresAtRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "SerieExpiresAtLabelText", ResourceType = typeof(Messages))]
        public DateTime ExpiresAt { get; set; }

        [Display(Name = "SerieIsActivatedLabelText", ResourceType = typeof(Messages))]
        public bool IsActivated { get; set; }

        #endregion
    }
}
