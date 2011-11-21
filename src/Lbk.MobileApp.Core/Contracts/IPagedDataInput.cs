// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPagedDataInput.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Core.Contracts
{
    public interface IPagedDataInput
    {
        #region - Properties -

        bool Ascending { get; set; }

        int Page { get; set; }

        int PageIndex { get; set; }

        int PageSize { get; set; }

        string Sort { get; set; }

        string SortDir { get; set; }

        #endregion
    }
}
