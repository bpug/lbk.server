// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GenericListViewModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models
{
    #region using directives

    using Lbk.MobileApp.Core;

    #endregion

    public class GenericListViewModel<TEntity, TSearchFormEntity>
    {
        #region - Properties -

        public PagedDataList<TEntity> Results { get; set; }

        public TSearchFormEntity SearchItem { get; set; }

        #endregion
    }
}
