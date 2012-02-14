// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoSearchFormModel.cs" company="ip-connect GmbH">
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

    public class VideoSearchFormModel : BaseFormModel
    {
        #region - Properties -

        [StringLength(255, ErrorMessageResourceName = "VideoDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "VideoDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "VideoDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        [StringLength(255, ErrorMessageResourceName = "VideoFileNameStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "VideoFileNameRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "VideoFileNameLabelText", ResourceType = typeof(Messages))]
        public string FileName { get; set; }

        [StringLength(255, ErrorMessageResourceName = "VideoLinkStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "VideoLinkRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "VideoLinkLabelText", ResourceType = typeof(Messages))]
        public string Link { get; set; }

        #endregion
    }
}
