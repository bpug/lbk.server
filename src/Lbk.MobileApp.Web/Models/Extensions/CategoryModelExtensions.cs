// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryModelExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using Lbk.MobileApp.Model;

    #endregion

    public static class CategoryModelExtensions
    {
        #region - Public Methods -

        public static CategorySearchFormModel GetValueOrDefault(this CategorySearchFormModel item)
        {
            if (item == null || (string.IsNullOrWhiteSpace(item.Title) && string.IsNullOrWhiteSpace(item.Description)))
            {
                return null;
            }

            return item;
        }

        public static CategoryFormModel ToFormModel(this Category model)
        {
            if (model == null)
            {
                return null;
            }

            return new CategoryFormModel { Id = model.Id, Description = model.Description, Title = model.Title };
        }

        public static Category ToModel(this CategorySearchFormModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Category { Id = model.Id, Description = model.Description, Title = model.Title };
        }

        public static CategorySearchFormModel ToSearchFormModel(this Category model)
        {
            if (model == null)
            {
                return null;
            }

            return new CategorySearchFormModel { Id = model.Id, Description = model.Description, Title = model.Title };
        }

        #endregion
    }
}
