// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodListViewModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models
{
    #region using directives

    using System.ComponentModel.DataAnnotations;

    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Model;
    using Lbk.MobileApp.Web.Models.Extensions;

    #endregion

    public class FoodListViewModel : Food
    {
        #region - Properties -

        [Display(Name = "FoodCategoryNameLabelText", ResourceType = typeof(Messages))]
        public string CategoryName
        {
            get
            {
                return this.Category != null ? this.Category.GetCategoryCompleteDescription() : "none";
            }
        }

        #endregion
    }
}
