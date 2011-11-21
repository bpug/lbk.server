// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionSearchFormModel.cs" company="ip-connect GmbH">
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

    public class QuestionSearchFormModel : BaseFormModel
    {
        #region - Properties -

        [StringLength(255, ErrorMessageResourceName = "QuestionDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "QuestionDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "QuestionDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        [Range(1, 255, ErrorMessageResourceName = "QuestionNumberIntRangeValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "QuestionNumberRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "QuestionNumberLabelText", ResourceType = typeof(Messages))]
        public int? Number { get; set; }

        [Range(1, 255, ErrorMessageResourceName = "QuestionPointsIntRangeValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "QuestionPointsRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "QuestionPointsLabelText", ResourceType = typeof(Messages))]
        public int? Points { get; set; }

        public long SerieId { get; set; }

        #endregion
    }
}
