// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Controllers
{
    #region using directives

    using System.Web.Mvc;

    using Lbk.MobileApp.Web.Extensions;

    #endregion

    public class HomeController : Controller
    {
        #region - Public Methods -

        public ActionResult About()
        {
            this.ViewData["AppSemanticVersion"] = AppInfoExtensions.GetApplicationSemanticVersion();
            this.ViewData["AppVersion"] = AppInfoExtensions.GetApplicationVersion();

            return this.View();
        }

        public ActionResult Index()
        {
            this.ViewBag.Message = "Welcome!";

            return this.View();
        }

        #endregion
    }
}
