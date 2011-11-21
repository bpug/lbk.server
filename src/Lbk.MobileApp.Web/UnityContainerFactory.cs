// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityContainerFactory.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web
{
    #region using directives

    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    #endregion

    public class UnityContainerFactory
    {
        #region - Public Methods -

        public IUnityContainer CreateConfiguredContainer()
        {
            var container = new UnityContainer();
            LoadConfigurationOverrides(container);
            return container;
        }

        #endregion

        #region - Methods -

        private static void LoadConfigurationOverrides(IUnityContainer container)
        {
            container.LoadConfiguration("container");
        }

        #endregion
    }
}
