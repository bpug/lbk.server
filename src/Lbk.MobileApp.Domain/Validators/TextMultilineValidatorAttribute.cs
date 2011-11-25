// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextMultilineValidatorAttribute.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Validators
{
    #region using directives

    using System.ComponentModel.DataAnnotations;

    using Lbk.MobileApp.Domain.Resources;

    #endregion

    public class TextMultilineValidatorAttribute : RegularExpressionAttribute
    {
        #region - Constructors and Destructors -

        public TextMultilineValidatorAttribute()
            : base(Messages.TextMultilineValidatorRegEx)
        {
            this.ErrorMessage = Messages.InvalidMultilineInput;
        }

        #endregion
    }
}
