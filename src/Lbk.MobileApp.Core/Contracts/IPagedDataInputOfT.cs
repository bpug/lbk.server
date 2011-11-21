// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPagedDataInputOfT.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Core.Contracts
{
    public interface IPagedDataInputOfT<T>
    {
        #region - Properties -

        T SearchItem { get; set; }

        #endregion
    }
}
