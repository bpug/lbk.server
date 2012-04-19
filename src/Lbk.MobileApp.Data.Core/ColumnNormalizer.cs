// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ColumnNormalizer.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.Core
{
    public static class ColumnNormalizer
    {
        #region - Public Methods -

        public static string FixupSortColumn(string sort)
        {
            if (string.IsNullOrWhiteSpace(sort))
            {
                return "Id";
            }

            return sort;
        }
        #endregion
    }
}
