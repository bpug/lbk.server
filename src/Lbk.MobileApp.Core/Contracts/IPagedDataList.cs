// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPagedDataList.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Core.Contracts
{
    #region using directives

    using System.Collections.Generic;

    #endregion

    public interface IPagedDataList<T> : ICollection<T>
    {
        #region - Properties -

        bool HasNextPage { get; }

        bool HasPreviousPage { get; }

        bool IsFirstPage { get; }

        bool IsLastPage { get; }

        int PageCount { get; }

        int PageIndex { get; }

        int PageNumber { get; }

        int PageSize { get; }

        int TotalItemCount { get; }

        #endregion
    }
}
