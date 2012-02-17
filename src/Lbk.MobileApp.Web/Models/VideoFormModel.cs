﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoFormModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models
{
    #region using directives

    using System.ComponentModel.DataAnnotations;

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Domain.Validators;

    #endregion

    public class VideoFormModel : BaseFormModel, ICreateVideoCommand
    {
        #region - Properties -

        [DataType(DataType.MultilineText)]
        [StringLength(255, ErrorMessageResourceName = "VideoDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextMultilineValidator]
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

        [Range(1, 10000, ErrorMessageResourceName = "VideoSortOrderRangeValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "VideoSortOrderRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "VideoSortOrderLabelText", ResourceType = typeof(Messages))]
        public int SortOrder { get; set; }

        [StringLength(255, ErrorMessageResourceName = "VideoThumbnailLinkStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Display(Name = "VideoThumbnailLinkLabelText", ResourceType = typeof(Messages))]
        public string ThumbnailLink { get; set; }

        #endregion
    }
}
