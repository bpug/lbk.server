// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddQuestion.cs" company="ip-connect GmbH">
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

    public class AddQuestion
    {
        #region - Constants and Fields -

        private readonly IQuestionRepository _questionRepository;

        #endregion

        #region - Constructors and Destructors -

        public AddQuestion(IQuestionRepository questionRepository)
        {
            this._questionRepository = questionRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long serieId, ICreateQuestionCommand question)
        {
            if (question == null)
            {
                throw new ArgumentNullException("question");
            }

            try
            {
                var entity = question.ToEntity();
                this._questionRepository.Create(serieId, entity);

                question.Id = entity.Id;
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToAddQuestionExceptionMessage, ex);
            }
        }

        #endregion
    }
}
