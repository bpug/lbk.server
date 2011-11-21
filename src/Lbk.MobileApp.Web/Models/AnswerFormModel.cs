// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerFormModel.cs" company="ip-connect GmbH">
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

    public class AnswerFormModel : BaseFormModel, ICreateAnswerCommand
    {
        #region - Properties -

        [StringLength(255, ErrorMessageResourceName = "AnswerDescriptionStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        [Required(AllowEmptyStrings = false, ErrorMessageResourceName = "AnswerDescriptionRequired", 
            ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "AnswerDescriptionLabelText", ResourceType = typeof(Messages))]
        public string Description { get; set; }

        [StringLength(255, ErrorMessageResourceName = "AnswerExplanationStringLengthValidationError", 
            ErrorMessageResourceType = typeof(Messages))]
        [TextLineInputValidator]
        ////[Required(AllowEmptyStrings = false, ErrorMessageResourceName = "AnswerExplanationRequired", 
        ////    ErrorMessageResourceType = typeof(Messages))]
        [Display(Name = "AnswerExplanationLabelText", ResourceType = typeof(Messages))]
        public string Explanation { get; set; }

        [Display(Name = "AnswerIsRightLabelText", ResourceType = typeof(Messages))]
        public bool IsRight { get; set; }

        public long QuestionId { get; set; }

        #endregion
    }
}
