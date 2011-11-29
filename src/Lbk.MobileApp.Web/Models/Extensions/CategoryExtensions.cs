// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using Lbk.MobileApp.Model;

    #endregion

    public static class CategoryExtensions
    {
        #region - Public Methods -

        public static string GetCategoryCompleteDescription(this Category category)
        {
            return !string.IsNullOrWhiteSpace(category.Description)
                       ? string.Format("{0} : {1}", category.Title, category.Description)
                       : category.Title;
        }

        #endregion
    }
}
