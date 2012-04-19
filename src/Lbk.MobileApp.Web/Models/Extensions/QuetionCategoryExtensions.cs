// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuetionCategoryExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using Lbk.MobileApp.Model;

    #endregion

    public static class QuetionCategoryExtensions
    {
        #region - Public Methods -

        public static string GetCategoryCompleteDescription(this QuestionCategory category)
        {
            return !string.IsNullOrWhiteSpace(category.Title)
                       ? category.Title
                       : string.Empty;
        }

        #endregion
    }
}
