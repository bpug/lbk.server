// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppInfoExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Extensions
{
    #region using directives

    using System.Diagnostics;
    using System.Reflection;

    using Gpo.SemanticVersion.Core;
    using Gpo.SemanticVersion.Core.Extensions;

    #endregion

    public static class AppInfoExtensions
    {
        #region - Public Methods -

        public static string GetApplicationSemanticVersion()
        {
            return SemanticVersionInfo.GetSemanticVersion(Assembly.GetExecutingAssembly()).ToDetailString();
        }

        public static string GetApplicationVersion(bool usePrefix = false)
        {
            var fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            return usePrefix ? string.Format("v{0}", fileVersion.FileVersion) : fileVersion.FileVersion;
        }

        #endregion
    }
}
