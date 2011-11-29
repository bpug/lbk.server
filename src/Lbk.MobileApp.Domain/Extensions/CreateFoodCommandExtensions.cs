// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateFoodCommandExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Extensions
{
    #region using directives

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Model;

    #endregion

    public static class CreateFoodCommandExtensions
    {
        #region - Public Methods -

        public static Food ToEntity(this ICreateFoodCommand source)
        {
            if (source == null)
            {
                return null;
            }

            return new Food
                {
                    CategoryId = source.CategoryId, 
                    Description = source.Description, 
                    Id = source.Id, 
                    MenuId = source.MenuId, 
                    Price = source.Price, 
                    SortOrder = source.SortOrder, 
                    Title = source.Title
                };
        }

        #endregion
    }
}
