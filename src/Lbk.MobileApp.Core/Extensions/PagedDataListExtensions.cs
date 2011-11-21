// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedDataListExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Core.Extensions
{
    #region using directives

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public static class PagedDataListExtensions
    {
        #region - Public Methods -

        public static PagedDataList<T> ToPagedDataList<T>(
            this IQueryable<T> source, int pageIndex, int pageSize, int? totalCount = null)
        {
            return new PagedDataList<T>(source, pageIndex, pageSize, totalCount);
        }

        public static PagedDataList<T> ToPagedDataList<T>(
            this IEnumerable<T> source, int pageIndex, int pageSize, int? totalCount = null)
        {
            return new PagedDataList<T>(source, pageIndex, pageSize, totalCount);
        }

        #endregion
    }
}
