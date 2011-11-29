// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateCategoryCommand.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Contracts
{
    public interface ICreateCategoryCommand
    {
        #region - Properties -

        string Description { get; set; }

        long Id { get; set; }

        string Title { get; set; }

        #endregion
    }
}
