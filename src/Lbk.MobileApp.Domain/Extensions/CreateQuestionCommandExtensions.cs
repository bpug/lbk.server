// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateQuestionCommandExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Extensions
{
    #region using directives

    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Model;

    #endregion

    public static class CreateQuestionCommandExtensions
    {
        #region - Public Methods -

        public static Question ToEntity(this ICreateQuestionCommand source)
        {
            if (source == null)
            {
                return null;
            }

            return new Question
                {
                    Description = source.Description, 
                    Id = source.Id, 
                    Number = source.Number, 
                    Points = source.Points, 
                    SerieId = source.SerieId
                };
        }

        #endregion
    }
}
