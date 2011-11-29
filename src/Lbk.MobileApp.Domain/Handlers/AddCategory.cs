// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddCategory.cs" company="ip-connect GmbH">
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

    public class AddCategory
    {
        #region - Constants and Fields -

        private readonly ICategoryRepository _categoryRepository;

        #endregion

        #region - Constructors and Destructors -

        public AddCategory(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateCategoryCommand category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }

            try
            {
                var entity = category.ToEntity();
                this._categoryRepository.Create(entity);

                category.Id = entity.Id;
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToAddCategoryExceptionMessage, ex);
            }
        }

        #endregion
    }
}
