// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateMenu.cs" company="ip-connect GmbH">
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

    public class UpdateMenu
    {
        #region - Constants and Fields -

        private readonly IMenuRepository _menuRepository;

        #endregion

        #region - Constructors and Destructors -

        public UpdateMenu(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateMenuCommand serie)
        {
            try
            {
                this._menuRepository.Update(serie.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToUpdateMenuExceptionMessage, ex);
            }
        }

        #endregion
    }
}
