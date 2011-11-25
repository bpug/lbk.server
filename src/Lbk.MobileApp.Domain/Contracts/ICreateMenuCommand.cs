// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateMenuCommand.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Contracts
{
    #region using directives

    using System;

    #endregion

    public interface ICreateMenuCommand
    {
        #region - Properties -

        DateTime Date { get; set; }

        string Description { get; set; }

        long Id { get; set; }

        #endregion
    }
}
