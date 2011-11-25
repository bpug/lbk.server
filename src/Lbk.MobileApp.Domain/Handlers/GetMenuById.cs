// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetMenuById.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Model;

    #endregion

    public class GetMenuById
    {
        #region - Constants and Fields -

        private readonly IMenuRepository _menuRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetMenuById(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual Menu Execute(long id)
        {
            try
            {
                return this._menuRepository.GetMenu(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveMenuExceptionMessage, ex);
            }
        }

        #endregion
    }
}
