// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedDataInputOfT.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Core
{
    #region using directives

    using System;

    using Lbk.MobileApp.Core.Contracts;

    #endregion

    [Serializable]
    public class PagedDataInput<T> : PagedDataInput, IPagedDataInputOfT<T>
    {
        #region - Constructors and Destructors -

        public PagedDataInput()
        {
        }

        public PagedDataInput(IPagedDataInput pagedDataInput)
        {
            if (pagedDataInput == null)
            {
                throw new ArgumentNullException("pagedDataInput");
            }

            this.PageIndex = pagedDataInput.PageIndex;
            this.PageSize = pagedDataInput.PageSize;
            this.Sort = pagedDataInput.Sort;
            this.SortDir = pagedDataInput.SortDir;
        }

        #endregion

        #region - Properties -

        public T SearchItem { get; set; }

        #endregion
    }
}
