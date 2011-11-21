// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAnswerRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface IAnswerRepository
    {
        #region - Public Methods -

        void Create(long questionId, Answer answer);

        void Delete(long answerId);

        Answer GetAnswer(long answerId);

        PagedDataList<Answer> GetAnswers(PagedDataInput<Answer> pagedDataInput);

        void Update(Answer answer);

        #endregion
    }
}
