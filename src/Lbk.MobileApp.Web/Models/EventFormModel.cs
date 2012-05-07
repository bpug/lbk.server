// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventFormModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using System.IO;
using System.Web;

namespace Lbk.MobileApp.Web.Models
{
    #region using directives

    using System;
    using System.ComponentModel.DataAnnotations;

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Domain.Validators;

    #endregion

    public class EventFormModel : BaseFormModel, ICreateEventCommand
    {
        #region - Properties -

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EventActivatedAtRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "EventActivatedAtLabelText", ResourceType = typeof(Messages))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime ActivatedAt { get; set; }

        [StringLength(255, ErrorMessageResourceName = "EventDateStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EventDateRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "EventDateLabelText", ResourceType = typeof(Messages))]
        public string Date { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EventDateOrderRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "EventDateOrderLabelText", ResourceType = typeof(Messages))]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime DateOrder { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(255, ErrorMessageResourceName = "EventDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextMultilineValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EventDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "EventDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EventExpiresAtRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "EventExpiresAtLabelText", ResourceType = typeof(Messages))]
        public DateTime ExpiresAt { get; set; }

        [Display(Name = "EventIsActivatedLabelText", ResourceType = typeof(Messages))]
        public bool IsActivated { get; set; }

        [StringLength(255, ErrorMessageResourceName = "EventReservationLinkStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Display(Name = "EventReservationLinkLabelText", ResourceType = typeof(Messages))]
        public string ReservationLink { get; set; }

        [StringLength(255, ErrorMessageResourceName = "EventThumbnailLinkStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Display(Name = "EventThumbnailLinkLabelText", ResourceType = typeof(Messages))]
        public string ThumbnailLink { get; set; }

        [StringLength(255, ErrorMessageResourceName = "EventTitleStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "EventTitleRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "EventTitleLabelText", ResourceType = typeof(Messages))]
        public string Title { get; set; }

        [Display(Name = "EventThumbnailLabelText", ResourceType = typeof(Messages))]
        public HttpPostedFileBase Thumbnail { get; set; }

        [Display(Name = "ThumbnailNameLabelText", ResourceType = typeof(Messages))]
        public string ThumbnailName { get; set; }

        public string ThumbnailLocation
        {
            get
            {
                if (string.IsNullOrEmpty(ThumbnailName))
                    return string.Empty;

                var path = ConfigurationManager.AppSettings["EventThumbnailHttpBasePath"];
                return Path.Combine(path, ThumbnailName);
            }
        }

        #endregion
    }
}
