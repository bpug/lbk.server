using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lbk.MobileApp.Web.Extensions
{
    using System.Web.Mvc;

    public static class HtmlHelperExtensions
    {
        public static string Script(this HtmlHelper html, string path)
        {
            var filePath = VirtualPathUtility.ToAbsolute(path);
            HttpContextBase context = html.ViewContext.HttpContext;
            // don't add the file if it's already there
            if (context.Items.Contains(filePath))
                return "";
            return "<script type=\"text/javascript\" src=\"" + filePath + "\"></script>";
        }
    }

}