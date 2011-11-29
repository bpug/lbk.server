// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCategoryById.cs" company="ip-connect GmbH">
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

    public class GetCategoryById
    {
        #region - Constants and Fields -

        private readonly ICategoryRepository _categoryRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetCategoryById(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual Category Execute(long id)
        {
            try
            {
                return this._categoryRepository.GetCategory(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveCategoryExceptionMessage, ex);
            }
        }

        #endregion
    }
}
