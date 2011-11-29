// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddMenu.cs" company="ip-connect GmbH">
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

    public class AddMenu
    {
        #region - Constants and Fields -

        private readonly IMenuRepository _menuRepository;

        #endregion

        #region - Constructors and Destructors -

        public AddMenu(IMenuRepository menuRepository)
        {
            this._menuRepository = menuRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateMenuCommand menu)
        {
            if (menu == null)
            {
                throw new ArgumentNullException("menu");
            }

            try
            {
                var entity = menu.ToEntity();
                this._menuRepository.Create(entity);

                menu.Id = entity.Id;
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToAddMenuExceptionMessage, ex);
            }
        }

        #endregion
    }
}
