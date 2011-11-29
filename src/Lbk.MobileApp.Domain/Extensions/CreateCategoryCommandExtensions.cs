// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCategoryCommandExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Extensions
{
    #region using directives

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Model;

    #endregion

    public static class CreateCategoryCommandExtensions
    {
        #region - Public Methods -

        public static Category ToEntity(this ICreateCategoryCommand source)
        {
            if (source == null)
            {
                return null;
            }

            return new Category { Description = source.Description, Id = source.Id, Title = source.Title };
        }

        #endregion
    }
}
