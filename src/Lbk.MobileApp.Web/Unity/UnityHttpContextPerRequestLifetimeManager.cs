// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityHttpContextPerRequestLifetimeManager.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Unity
{
    public class UnityHttpContextPerRequestLifetimeManager : UnityPerRequestLifetimeManager
    {
        #region - Constructors and Destructors -

        public UnityHttpContextPerRequestLifetimeManager()
            : base(new HttpContextPerRequestStore())
        {
        }

        #endregion
    }
}
