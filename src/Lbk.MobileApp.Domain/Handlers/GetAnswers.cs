// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetAnswers.cs" company="ip-connect GmbH">
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

    public class GetAnswers
    {
        #region - Constants and Fields -

        private readonly IAnswerRepository _answerRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetAnswers(IAnswerRepository answerRepository)
        {
            this._answerRepository = answerRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual PagedDataList<Answer> Execute(PagedDataInput<Answer> pagedDataInput)
        {
            try
            {
                return this._answerRepository.GetAnswers(pagedDataInput);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveAnswerExceptionMessage, ex);
            }
        }

        #endregion
    }
}
