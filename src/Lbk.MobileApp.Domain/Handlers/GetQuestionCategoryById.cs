// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetQuestionCategoryById.cs" company="ip-connect GmbH">
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

    public class GetQuestionCategoryById
    {
        #region - Constants and Fields -

        private readonly IQuestionCategoryRepository _categoryRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetQuestionCategoryById(IQuestionCategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual QuestionCategory Execute(long id)
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
