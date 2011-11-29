// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteMenuById.cs" company="ip-connect GmbH">
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

    #endregion

    public class DeleteMenuById
    {
        #region - Constants and Fields -

        private readonly IMenuRepository _menuRepository;

        #endregion

        #region - Constructors and Destructors -

        public DeleteMenuById(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long id)
        {
            try
            {
                this._menuRepository.Delete(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToDeleteMenuExceptionMessage, ex);
            }
        }

        #endregion
    }
}
