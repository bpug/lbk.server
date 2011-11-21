// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetQuestionById.cs" company="ip-connect GmbH">
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

    public class GetQuestionById
    {
        #region - Constants and Fields -

        private readonly IQuestionRepository _questionRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetQuestionById(IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual Question Execute(long id)
        {
            try
            {
                return this._questionRepository.GetQuestion(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveQuestionExceptionMessage, ex);
            }
        }

        #endregion
    }
}
