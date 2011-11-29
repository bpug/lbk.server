// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetCategories.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Model;

    #endregion

    public class GetCategories
    {
        #region - Constants and Fields -

        private readonly ICategoryRepository _categroryRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetCategories(ICategoryRepository categoryRepository)
        {
            this._categroryRepository = categoryRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual PagedDataList<Category> Execute(PagedDataInput<Category> pagedDataInput)
        {
            try
            {
                return this._categroryRepository.GetCategories(pagedDataInput);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveCategoryExceptionMessage, ex);
            }
        }

        #endregion
    }
}
