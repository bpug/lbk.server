using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Lbk.MobileApp.Web.Controllers
{
    public class LocaleController : Controller
    {
        //
        // GET: /Locale/

        [HttpGet]
        public ActionResult CurrentCulture()
        {
            return Json(Thread.CurrentThread.CurrentCulture.IetfLanguageTag, JsonRequestBehavior.AllowGet);
        }

    }
}
