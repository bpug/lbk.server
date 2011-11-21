// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQuestionRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface IQuestionRepository
    {
        #region - Public Methods -

        void Create(long serieId, Question question);

        void Delete(long questionId);

        Question GetQuestion(long questionId);

        PagedDataList<Question> GetQuestions(PagedDataInput<Question> pagedDataInput);

        void Update(Question question);

        #endregion
    }
}
