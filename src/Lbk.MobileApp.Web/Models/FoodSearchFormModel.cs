// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodSearchFormModel.cs" company="ip-connect GmbH">
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

    public class FoodSearchFormModel : BaseFormModel
    {
        #region - Properties -

        public long CategoryId { get; set; }

        [StringLength(255, ErrorMessageResourceName = "FoodDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextMultilineValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "FoodDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "FoodDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        public long MenuId { get; set; }

        [StringLength(255, ErrorMessageResourceName = "FoodTitleStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "FoodTitleRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "FoodTitleLabelText", ResourceType = typeof(Messages))]
        public string Title { get; set; }

        #endregion
    }
}
