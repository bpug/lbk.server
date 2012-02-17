// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodFormModel.cs" company="ip-connect GmbH">
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

    public class FoodFormModel : BaseFormModel, ICreateFoodCommand
    {
        #region - Properties -

        [Display(Name = "FoodCategoryIdLabelText", ResourceType = typeof(Messages))]
        public long CategoryId { get; set; }

        public string CategoryName { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(255, ErrorMessageResourceName = "FoodDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextMultilineValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "FoodDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "FoodDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        public long MenuId { get; set; }

        [Range(0.0d, 1000.0d, ErrorMessageResourceName = "FoodPriceRangeValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "FoodPriceRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "FoodPriceLabelText", ResourceType = typeof(Messages))]
        public decimal Price { get; set; }

        [Range(1, 10000, ErrorMessageResourceName = "FoodSortOrderRangeValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "FoodSortOrderRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "FoodSortOrderLabelText", ResourceType = typeof(Messages))]
        public int SortOrder { get; set; }

        [StringLength(255, ErrorMessageResourceName = "FoodTitleStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Display(Name = "FoodTitleLabelText", ResourceType = typeof(Messages))]
        public string Title { get; set; }

        #endregion
    }
}
