// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPerRequestStore.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Unity
{
    #region using directives

    using System;

    #endregion

    public interface IPerRequestStore
    {
        #region - Events -

        event EventHandler EndRequest;

        #endregion

        #region - Public Methods -

        object GetValue(object key);

        void RemoveValue(object key);

        void SetValue(object key, object value);

        #endregion
    }
}
