// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddAnswer.cs" company="ip-connect GmbH">
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

    public class AddAnswer
    {
        #region - Constants and Fields -

        private readonly IAnswerRepository _answerRepository;

        #endregion

        #region - Constructors and Destructors -

        public AddAnswer(IAnswerRepository answerRepository)
        {
            this._answerRepository = answerRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long questionId, ICreateAnswerCommand answer)
        {
            if (answer == null)
            {
                throw new ArgumentNullException("answer");
            }

            try
            {
                var entity = answer.ToEntity();
                this._answerRepository.Create(questionId, entity);

                answer.Id = entity.Id;
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToAddAnswerExceptionMessage, ex);
            }
        }

        #endregion
    }
}
