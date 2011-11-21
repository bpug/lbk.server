// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PagedDataInput.cs" company="ip-connect GmbH">
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
    public class PagedDataInput : IPagedDataInput
    {
        #region - Properties -

        public bool Ascending
        {
            get
            {
                return this.SortDir == null || this.SortDir.ToLower() != "desc";
            }

            set
            {
                this.SortDir = value ? "asc" : "desc";
            }
        }

        public int Page
        {
            get
            {
                return this.PageIndex + 1;
            }

            set
            {
                this.PageIndex = value - 1;
            }
        }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public string Sort { get; set; }

        public string SortDir { get; set; }

        #endregion
    }
}
