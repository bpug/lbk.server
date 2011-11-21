// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateAnswer.cs" company="ip-connect GmbH">
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

    public class UpdateAnswer
    {
        #region - Constants and Fields -

        private readonly IAnswerRepository _answerRepository;

        #endregion

        #region - Constructors and Destructors -

        public UpdateAnswer(IAnswerRepository answerRepository)
        {
            this._answerRepository = answerRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateAnswerCommand answer)
        {
            try
            {
                this._answerRepository.Update(answer.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToUpdateAnswerExceptionMessage, ex);
            }
        }

        #endregion
    }
}
