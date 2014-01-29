// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments
#pragma warning disable 1591
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Lbk.MobileApp.Web.Controllers
{
    public partial class AccountController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AccountController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }


        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AccountController Actions { get { return MVC.Account; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Account";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Account";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string ChangePassword = "ChangePassword";
            public readonly string ChangePasswordSuccess = "ChangePasswordSuccess";
            public readonly string LogOff = "LogOff";
            public readonly string LogOn = "LogOn";
            public readonly string GeneratePassword = "GeneratePassword";
            public readonly string Register = "Register";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string ChangePassword = "ChangePassword";
            public const string ChangePasswordSuccess = "ChangePasswordSuccess";
            public const string LogOff = "LogOff";
            public const string LogOn = "LogOn";
            public const string GeneratePassword = "GeneratePassword";
            public const string Register = "Register";
        }


        static readonly ActionParamsClass_ChangePassword s_params_ChangePassword = new ActionParamsClass_ChangePassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChangePassword ChangePasswordParams { get { return s_params_ChangePassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChangePassword
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_LogOn s_params_LogOn = new ActionParamsClass_LogOn();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_LogOn LogOnParams { get { return s_params_LogOn; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_LogOn
        {
            public readonly string model = "model";
            public readonly string returnUrl = "returnUrl";
        }
        static readonly ActionParamsClass_Register s_params_Register = new ActionParamsClass_Register();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Register RegisterParams { get { return s_params_Register; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Register
        {
            public readonly string model = "model";
        }
        static readonly ActionParamsClass_GeneratePassword s_params_GeneratePassword = new ActionParamsClass_GeneratePassword();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GeneratePassword GeneratePasswordParams { get { return s_params_GeneratePassword; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GeneratePassword
        {
            public readonly string model = "model";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string ChangePassword = "ChangePassword";
                public readonly string ChangePasswordSuccess = "ChangePasswordSuccess";
                public readonly string GeneratePassword = "GeneratePassword";
                public readonly string LogOn = "LogOn";
                public readonly string Register = "Register";
            }
            public readonly string ChangePassword = "~/Views/Account/ChangePassword.cshtml";
            public readonly string ChangePasswordSuccess = "~/Views/Account/ChangePasswordSuccess.cshtml";
            public readonly string GeneratePassword = "~/Views/Account/GeneratePassword.cshtml";
            public readonly string LogOn = "~/Views/Account/LogOn.cshtml";
            public readonly string Register = "~/Views/Account/Register.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AccountController : Lbk.MobileApp.Web.Controllers.AccountController
    {
        public T4MVC_AccountController() : base(Dummy.Instance) { }

        [NonAction]
        partial void ChangePasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ChangePassword()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangePassword);
            ChangePasswordOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ChangePasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Lbk.MobileApp.Web.Models.ChangePasswordModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult ChangePassword(Lbk.MobileApp.Web.Models.ChangePasswordModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangePassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ChangePasswordOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void ChangePasswordSuccessOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ChangePasswordSuccess()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangePasswordSuccess);
            ChangePasswordSuccessOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void LogOffOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult LogOff()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LogOff);
            LogOffOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void LogOnOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult LogOn()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LogOn);
            LogOnOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void GeneratePasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult GeneratePassword()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GeneratePassword);
            GeneratePasswordOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void LogOnOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Lbk.MobileApp.Web.Models.LogOnModel model, string returnUrl);

        [NonAction]
        public override System.Web.Mvc.ActionResult LogOn(Lbk.MobileApp.Web.Models.LogOnModel model, string returnUrl)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.LogOn);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "returnUrl", returnUrl);
            LogOnOverride(callInfo, model, returnUrl);
            return callInfo;
        }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Register()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            RegisterOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void RegisterOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Lbk.MobileApp.Web.Models.RegisterModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult Register(Lbk.MobileApp.Web.Models.RegisterModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Register);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            RegisterOverride(callInfo, model);
            return callInfo;
        }

        [NonAction]
        partial void GeneratePasswordOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Lbk.MobileApp.Web.Models.GeneratePasswordModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult GeneratePassword(Lbk.MobileApp.Web.Models.GeneratePasswordModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GeneratePassword);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            GeneratePasswordOverride(callInfo, model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591
