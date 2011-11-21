// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateAnswerCommandExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Extensions
{
    #region using directives

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Model;

    #endregion

    public static class CreateAnswerCommandExtensions
    {
        #region - Public Methods -

        public static Answer ToEntity(this ICreateAnswerCommand source)
        {
            if (source == null)
            {
                return null;
            }

            return new Answer
                {
                    Description = source.Description, 
                    Explanation = source.Explanation, 
                    Id = source.Id, 
                    IsRight = source.IsRight, 
                    QuestionId = source.QuestionId
                };
        }

        #endregion
    }
}
