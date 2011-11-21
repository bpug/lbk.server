// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BusinessServicesException.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Contracts
{
    #region using directives

    using System;

    #endregion

    [Serializable]
    public class BusinessServicesException : Exception
    {
        #region - Constructors and Destructors -

        public BusinessServicesException()
        {
        }

        public BusinessServicesException(string message)
            : base(message)
        {
        }

        public BusinessServicesException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        #endregion
    }
}
