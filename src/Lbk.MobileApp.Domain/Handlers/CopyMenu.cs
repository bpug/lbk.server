// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopyMenu.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Extensions;
    using Lbk.MobileApp.Domain.Resources;

    #endregion

    public class CopyMenu
    {
        #region - Constants and Fields -

        private readonly IMenuRepository _menuRepository;

        #endregion

        #region - Constructors and Destructors -

        public CopyMenu(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateMenuCommand menu)
        {
            try
            {
                this._menuRepository.Copy(menu.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToCopyMenuExceptionMessage, ex);
            }
        }

        #endregion
    }
}
