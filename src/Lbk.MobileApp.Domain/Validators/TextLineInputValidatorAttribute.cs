// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextLineInputValidatorAttribute.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Validators
{
    #region using directives

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using Lbk.MobileApp.Domain.Resources;

    #endregion

    public class TextLineInputValidatorAttribute : RegularExpressionAttribute, IClientValidatable
    {
        #region - Constructors and Destructors -

        public TextLineInputValidatorAttribute()
            : base(Messages.TextLineInputValidatorRegEx)
        {
            this.ErrorMessage = Messages.InvalidInputCharacter;
        }

        #endregion

        #region - Implemented Interfaces -

        #region IClientValidatable

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(
            ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
                {
                   ErrorMessage = Messages.InvalidInputCharacter, ValidationType = "textlineinput" 
                };

            rule.ValidationParameters.Add("pattern", Messages.TextLineInputValidatorRegEx);
            return new List<ModelClientValidationRule> { rule };
        }

        #endregion

        #endregion
    }
}
