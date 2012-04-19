// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuestionCategoryRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface IQuestionCategoryRepository
    {
        #region - Public Methods -

        void Create(QuestionCategory category);

        void Delete(long categoryId);

        PagedDataList<QuestionCategory> GetCategories(PagedDataInput<QuestionCategory> pagedDataInput);

        QuestionCategory GetCategory(long categoryId);

        void Update(QuestionCategory category);

        #endregion
    }
}
