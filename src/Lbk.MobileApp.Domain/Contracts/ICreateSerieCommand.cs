// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateSerieCommand.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Contracts
{
    #region using directives

    using System;

    #endregion

    public interface ICreateSerieCommand
    {
        #region - Properties -

        DateTime ActivatedAt { get; set; }

        string Description { get; set; }

        DateTime ExpiresAt { get; set; }

        long Id { get; set; }

        bool IsActivated { get; set; }

        #endregion
    }
}
