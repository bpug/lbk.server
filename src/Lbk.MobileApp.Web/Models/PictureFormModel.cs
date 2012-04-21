// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureFormModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using System.IO;
using System.Web;

namespace Lbk.MobileApp.Web.Models
{
    #region using directives

    using System.ComponentModel.DataAnnotations;

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Domain.Validators;

    #endregion

    public class PictureFormModel : BaseFormModel, ICreatePictureCommand
    {
        #region - Properties -

        [StringLength(255, ErrorMessageResourceName = "PictureTitleStringLengthValidationError",
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PictureTitleRequired",
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "PictureTitleLabelText", ResourceType = typeof(Messages))]
        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(255, ErrorMessageResourceName = "PictureDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextMultilineValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PictureDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "PictureDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        [StringLength(255, ErrorMessageResourceName = "PictureFileNameStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PictureFileNameRequired",
        //    ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "PictureFileNameLabelText", ResourceType = typeof(Messages))]
        public string FileName { get; set; }

        [StringLength(255, ErrorMessageResourceName = "PictureLinkStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PictureLinkRequired", 
        //    ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "PictureLinkLabelText", ResourceType = typeof(Messages))]
        public string Link { get; set; }

        [Range(1, 10000, ErrorMessageResourceName = "PictureSortOrderRangeValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PictureSortOrderRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "PictureSortOrderLabelText", ResourceType = typeof(Messages))]
        public int SortOrder { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessageResourceName = "PictureFileRequired",
        //    ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "PictureFileLabelText", ResourceType = typeof(Messages))]
        public HttpPostedFileBase File { get; set; } 

        public string PictureLocation
        {
            get { return string.IsNullOrEmpty(Link) ? FilePath : Link; }
        }

        private string FilePath
        {
            get
            {
                if (string.IsNullOrEmpty(FileName))
                    return string.Empty;

                var path = ConfigurationManager.AppSettings["PictureHttpBasePath"];
                return Path.Combine(path, FileName);
            }
        }

        #endregion
    }
}
