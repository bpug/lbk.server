// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Extensions
{
    #region using directives

    using System.Text;

    using Lbk.MobileApp.Web.Serializer;

    #endregion

    public static class ObjectExtensions
    {
        #region - Public Methods -

        public static string SerializeToJavascript(this object source)
        {
            return JavaScriptSerializer.Serialize(source);
        }

        public static byte[] SerializeToJavascriptBytes(this object source)
        {
            return Encoding.Default.GetBytes(JavaScriptSerializer.Serialize(source));
        }

        #endregion
    }
}
