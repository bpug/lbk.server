// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateQuestion.cs" company="ip-connect GmbH">
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

    public class UpdateQuestion
    {
        #region - Constants and Fields -

        private readonly IQuestionRepository _questionRepository;

        #endregion

        #region - Constructors and Destructors -

        public UpdateQuestion(IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateQuestionCommand question)
        {
            try
            {
                this._questionRepository.Update(question.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToUpdateQuestionExceptionMessage, ex);
            }
        }

        #endregion
    }
}
