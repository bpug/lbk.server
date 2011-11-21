// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteQuestionById.cs" company="ip-connect GmbH">
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

    public class DeleteQuestionById
    {
        #region - Constants and Fields -

        private readonly IQuestionRepository _questionRepository;

        #endregion

        #region - Constructors and Destructors -

        public DeleteQuestionById(IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long id)
        {
            try
            {
                this._questionRepository.Delete(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToDeleteQuestionExceptionMessage, ex);
            }
        }

        #endregion
    }
}
