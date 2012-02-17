// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryFormModel.cs" company="ip-connect GmbH">
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

    public class CategoryFormModel : BaseFormModel, ICreateCategoryCommand
    {
        #region - Properties -

        [DataType(DataType.MultilineText)]
        [StringLength(255, ErrorMessageResourceName = "CategoryDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextMultilineValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "CategoryDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "CategoryDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        [StringLength(255, ErrorMessageResourceName = "CategoryTitleStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "CategoryTitleRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "CategoryTitleLabelText", ResourceType = typeof(Messages))]
        public string Title { get; set; }

        #endregion
    }
}
