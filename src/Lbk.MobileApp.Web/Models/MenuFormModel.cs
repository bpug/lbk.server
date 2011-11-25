// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuFormModel.cs" company="ip-connect GmbH">
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

    public class MenuFormModel : BaseFormModel, ICreateMenuCommand
    {
        #region - Properties -

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "MenuDateRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "MenuDateLabelText", ResourceType = typeof(Messages))]
        public DateTime Date { get; set; }

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
