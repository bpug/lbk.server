// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateAnswerCommand.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Contracts
{
    public interface ICreateAnswerCommand
    {
        #region - Properties -

        string Description { get; set; }

        string Explanation { get; set; }

        long Id { get; set; }

        bool IsRight { get; set; }

        long QuestionId { get; set; }

        #endregion
    }
}
