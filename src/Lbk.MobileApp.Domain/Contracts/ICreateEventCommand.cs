// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateEventCommand.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Contracts
{
    #region using directives

    using System;

    #endregion

    public interface ICreateEventCommand
    {
        #region - Properties -

        DateTime ActivatedAt { get; set; }

        string Date { get; set; }

        DateTime DateOrder { get; set; }

        string Description { get; set; }

        DateTime ExpiresAt { get; set; }

        long Id { get; set; }

        bool IsActivated { get; set; }

        string ReservationLink { get; set; }

        string ThumbnailLink { get; set; }

        string Title { get; set; }

        string ThumbnailName { get; set; }
        

        #endregion
    }
}
