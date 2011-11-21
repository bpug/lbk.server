// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetQuestions.cs" company="ip-connect GmbH">
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

    public class GetQuestions
    {
        #region - Constants and Fields -

        private readonly IQuestionRepository _questionRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetQuestions(IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual PagedDataList<Question> Execute(PagedDataInput<Question> pagedDataInput)
        {
            try
            {
                return this._questionRepository.GetQuestions(pagedDataInput);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveQuestionExceptionMessage, ex);
            }
        }

        #endregion
    }
}
