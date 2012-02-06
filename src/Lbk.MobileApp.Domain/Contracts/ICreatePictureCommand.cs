// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreatePictureCommand.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Contracts
{
    public interface ICreatePictureCommand
    {
        #region - Properties -

        string Description { get; set; }

        string FileName { get; set; }

        long Id { get; set; }

        string Link { get; set; }

        int SortOrder { get; set; }

        #endregion
    }
}
