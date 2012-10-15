// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddVideo.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lbk.MobileApp.Web.Helpers
{
    using Lbk.MobileApp.Web.Extensions;

    public static class CultureHelper
    {
        private static readonly Dictionary<String, bool> _cultures = new Dictionary<String, bool> {
            {"de-DE", false}, // first culture is the DEFAULT
            {"en-US", false}
        };

        public static IHtmlString MetaAcceptLanguage<T>(this HtmlHelper<T> html)
        {
            return new HtmlString(String.Format(@"<meta name=""accept-language"" content=""{0}"" />", AcceptLanguage()));
        }

        public static IHtmlString GlobalizationLink<T>(this HtmlHelper<T> html)
        {
            var path =
                String.Format(@"~/Scripts/globalization/cultures/globalize.culture.{0}.js", AcceptLanguage());
            var filePath = VirtualPathUtility.ToAbsolute(path);

            return new HtmlString(html.Script(filePath));
            //return new HtmlString(String.Format(@"<script src=""/Scripts/globalization/cultures/globalize.culture.{0}.js"" type=""text/javascript""></script>",
            //    AcceptLanguage()));
        }

        /// <summary>
        /// Returns a valid culture name based on "name" parameter. If "name" is not valid, it returns the default culture "en-US"
        /// </summary>
        /// <param name="name">Culture's name (e.g. en-US)</param>
        public static string GetValidCulture(string name)
        {
            if (string.IsNullOrEmpty(name))
                return GetDefaultCulture(); // return Default culture

            if (_cultures.ContainsKey(name))
                return name;

            // Find a close match. For example, if you have "en-US" defined and the user requests "en-GB", 
            // the function will return closes match that is "en-US" because at least the language is the same (ie English)            
            foreach (var c in _cultures.Keys)
                if (c.StartsWith(name.Substring(0, 2)))
                    return c;

            return GetDefaultCulture(); // return Default culture as no match found
        }

        public static string GetDefaultCulture()
        {
            return _cultures.Keys.ElementAt(0); // return Default culture

        }

        public static string GetCultureFromCookies(HttpRequest request)
        {
            string cultureName = null;
            // Attempt to read the culture cookie from Request
            HttpCookie cultureCookie = request.Cookies["_culture"];
            if (cultureCookie != null)
            {
                cultureName = cultureCookie.Value;
            }
            else if (request.UserLanguages != null)
            {
                cultureName = request.UserLanguages[0]; // obtain it from HTTP header AcceptLanguages
            }

            // Validate culture name
            return GetValidCulture(cultureName); // This is safe
        }

        private static string AcceptLanguage()
        {
            return HttpUtility.HtmlAttributeEncode(System.Threading.Thread.CurrentThread.CurrentUICulture.ToString());
        }

       

        /// <summary>
        ///  Returns "true" if view is implemented separatley, and "false" if not.
        ///  For example, if "en-US" is true, then separate views must exist e.g. Index.en-us.cshtml, About.en-us.cshtml
        /// </summary>
        /// <param name="name">Culture's name</param>
        /// <returns></returns>
        public static bool IsViewSeparate(string name)
        {
            return _cultures[name];
        }
    }
}
