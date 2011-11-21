// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMenuRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface IMenuRepository
    {
        #region - Public Methods -

        void Create(Menu menu);

        void Delete(long menuId);

        Menu GetMenu(long menuId);

        PagedDataList<Menu> GetMenus(PagedDataInput<Menu> pagedDataInput);

        void Update(Menu menu);

        #endregion
    }
}
