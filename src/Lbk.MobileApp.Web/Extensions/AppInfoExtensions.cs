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

    using Gapon.SemanticVersion;

    #endregion

    public static class AppInfoExtensions
    {
        #region - Public Methods -

        public static string GetApplicationSemanticVersion()
        {
            return
                SemanticVersionInfo.GetSemanticVersion(
                    Assembly.GetExecutingAssembly(), 
                    SemanticVersionInfo.VersionAttribute.AssemblyInformationalVersionAttribute).ToString();
        }

        public static string GetApplicationVersion(bool usePrefix = false)
        {
            var fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            return usePrefix ? string.Format("v{0}", fileVersion.FileVersion) : fileVersion.FileVersion;
        }

        #endregion
    }
}
