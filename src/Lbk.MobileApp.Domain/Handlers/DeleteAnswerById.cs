// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteAnswerById.cs" company="ip-connect GmbH">
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

    #endregion

    public class DeleteAnswerById
    {
        #region - Constants and Fields -

        private readonly IAnswerRepository _answerRepository;

        #endregion

        #region - Constructors and Destructors -

        public DeleteAnswerById(IAnswerRepository answerRepository)
        {
            this._answerRepository = answerRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long id)
        {
            try
            {
                this._answerRepository.Delete(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToDeleteAnswerExceptionMessage, ex);
            }
        }

        #endregion
    }
}
