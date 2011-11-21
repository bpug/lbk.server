// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    public interface IUnitOfWork
    {
        #region - Public Methods -

        void SaveChanges();

        #endregion
    }
}
