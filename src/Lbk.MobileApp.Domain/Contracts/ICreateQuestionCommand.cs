// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateQuestionCommand.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Contracts
{
    public interface ICreateQuestionCommand
    {
        #region - Properties -

        string Description { get; set; }

        long Id { get; set; }

        int Number { get; set; }

        int Points { get; set; }

        long SerieId { get; set; }

        long CategoryId { get; set; }

        #endregion
    }
}
