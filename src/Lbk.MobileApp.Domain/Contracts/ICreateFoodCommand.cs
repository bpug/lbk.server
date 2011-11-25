// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICreateFoodCommand.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Contracts
{
    public interface ICreateFoodCommand
    {
        #region - Properties -

        long CategoryId { get; set; }

        string Description { get; set; }

        long Id { get; set; }

        long MenuId { get; set; }

        decimal Price { get; set; }

        int SortOrder { get; set; }

        string Title { get; set; }

        #endregion
    }
}
