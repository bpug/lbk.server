// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JavaScriptSerializer.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Serializer
{
    public static class JavaScriptSerializer
    {
        #region - Public Methods -

        public static T Deserialize<T>(string source)
        {
            var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return javaScriptSerializer.Deserialize<T>(source);
        }

        public static string Serialize(object source)
        {
            var javaScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            return javaScriptSerializer.Serialize(source);
        }

        #endregion
    }
}
