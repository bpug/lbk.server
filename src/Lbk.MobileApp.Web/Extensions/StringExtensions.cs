// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StringExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Extensions
{
    #region using directives

    using Lbk.MobileApp.Web.Serializer;

    #endregion

    public static class StringExtensions
    {
        #region - Public Methods -

        public static T DeserializeFromJavaScript<T>(this string source)
        {
            return JavaScriptSerializer.Deserialize<T>(source);
        }

        public static string GetValueOrDefault(this string source, string @default)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return @default;
            }
            return source;
        }

        #endregion
    }
}
