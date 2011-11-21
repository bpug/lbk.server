// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerieExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model.Extensions
{
    #region using directives

    using System;

    #endregion

    public static class SerieExtensions
    {
        #region - Public Methods -

        public static Serie GetValueOrDefault(this Serie item)
        {
            if (item == null
                ||
                (item.ActivatedAt <= new DateTime(1900, 01, 01) && string.IsNullOrWhiteSpace(item.Description)
                 && item.ExpiresAt <= new DateTime(1900, 01, 01)))
            {
                return null;
            }

            return item;
        }

        #endregion
    }
}
