// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateCategory.cs" company="ip-connect GmbH">
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

    public class UpdateCategory
    {
        #region - Constants and Fields -

        private readonly ICategoryRepository _categoryRepository;

        #endregion

        #region - Constructors and Destructors -

        public UpdateCategory(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateCategoryCommand category)
        {
            try
            {
                this._categoryRepository.Update(category.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToUpdateMenuExceptionMessage, ex);
            }
        }

        #endregion
    }
}
