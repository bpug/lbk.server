// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityDependencyResolver.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web
{
    #region using directives

    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Microsoft.Practices.Unity;

    #endregion

    public class UnityDependencyResolver : IDependencyResolver
    {
        #region - Constants and Fields -

        private readonly IUnityContainer _unity;

        #endregion

        #region - Constructors and Destructors -

        public UnityDependencyResolver(IUnityContainer unity)
        {
            this._unity = unity;
        }

        #endregion

        #region - Implemented Interfaces -

        #region IDependencyResolver

        public object GetService(Type serviceType)
        {
            try
            {
                return this._unity.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                // By definition of IDependencyResolver contract, this should return null if it cannot be found.
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this._unity.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                // By definition of IDependencyResolver contract, this should return null if it cannot be found.
                return null;
            }
        }

        #endregion

        #endregion
    }
}
