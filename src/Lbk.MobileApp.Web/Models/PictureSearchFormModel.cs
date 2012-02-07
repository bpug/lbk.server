// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureSearchFormModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models
{
    #region using directives

    using System.ComponentModel.DataAnnotations;

    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Domain.Validators;

    #endregion

    public class PictureSearchFormModel : BaseFormModel
    {
        #region - Properties -

        [StringLength(255, ErrorMessageResourceName = "PictureDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PictureDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "PictureDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        [StringLength(255, ErrorMessageResourceName = "PictureFileNameStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PictureFileNameRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "PictureFileNameLabelText", ResourceType = typeof(Messages))]
        public string FileName { get; set; }

        [StringLength(255, ErrorMessageResourceName = "PictureLinkStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PictureLinkRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "PictureLinkLabelText", ResourceType = typeof(Messages))]
        public string Link { get; set; }

        #endregion
    }
}
