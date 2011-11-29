// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteCategoryById.cs" company="ip-connect GmbH">
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

    public class DeleteCategoryById
    {
        #region - Constants and Fields -

        private readonly ICategoryRepository _categoryRepository;

        #endregion

        #region - Constructors and Destructors -

        public DeleteCategoryById(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long id)
        {
            try
            {
                this._categoryRepository.Delete(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToDeleteCategoryExceptionMessage, ex);
            }
        }

        #endregion
    }
}
