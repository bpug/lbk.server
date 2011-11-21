// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Models
{
    public abstract class BaseModel
    {
        #region - Properties -

        public virtual long Id { get; set; }

        #endregion
    }
}
