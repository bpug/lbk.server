// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web;
using Lbk.MobileApp.Web.Helpers;

namespace Lbk.MobileApp.Web.Controllers
{
    #region using directives

    using System.Web.Mvc;

    using Lbk.MobileApp.Web.Extensions;

    #endregion

    public partial class HomeController : Controller
    {
        #region - Public Methods -

        public virtual ActionResult About()
        {
            this.ViewData["AppSemanticVersion"] = AppInfoExtensions.GetApplicationSemanticVersion();
            this.ViewData["AppVersion"] = AppInfoExtensions.GetApplicationVersion();

            return this.View();
        }

        public virtual ActionResult Index()
        {
            this.ViewBag.Message = "Welcome!";

            return this.View();
        }

        public virtual ActionResult SetCulture(string culture, string currentAction, string currentController, string currentId)
        {
            // Validate input
            culture = CultureHelper.GetValidCulture(culture);

            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
            {
                cookie.Value = culture; // update cookie value
            }
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.HttpOnly = false; // Not accessible by JS.
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            //return RedirectToAction("Index");
            if (currentId != null)
            {
                return RedirectToAction(currentAction, currentController, new { id = currentId });
            }
            return RedirectToAction(currentAction, currentController);
        }

        #endregion
    }
}
