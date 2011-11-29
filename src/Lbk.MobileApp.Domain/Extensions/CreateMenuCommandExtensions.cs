// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateMenuCommandExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Extensions
{
    #region using directives

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Model;

    #endregion

    public static class CreateMenuCommandExtensions
    {
        #region - Public Methods -

        public static Menu ToEntity(this ICreateMenuCommand source)
        {
            if (source == null)
            {
                return null;
            }

            return new Menu { Date = source.Date, Description = source.Description, Id = source.Id };
        }

        #endregion
    }
}
