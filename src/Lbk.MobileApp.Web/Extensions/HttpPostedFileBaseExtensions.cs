// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpPostedFileBaseExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Extensions
{
    using System.Web;

    /// <summary>
    /// The http posted file base extensions.
    /// </summary>
    public static class HttpPostedFileBaseExtensions
    {
        #region Public Methods and Operators

        public static bool HasFile(this HttpPostedFileBase source)
        {
            return source != null && source.ContentLength > 0;
        }

        #endregion
    }
}