// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Configuration;

namespace Lbk.MobileApp.Web.Controllers
{
    #region using directives

    using System;
    using System.Web.Mvc;
    using System.Web.Security;

    using Lbk.MobileApp.Web.Models;

    #endregion

    public partial class AccountController : Controller
    {
        // GET: /Account/LogOn
        #region - Public Methods -

        [Authorize]
        public virtual ActionResult ChangePassword()
        {
            return this.View();
        }

        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public virtual ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (this.ModelState.IsValid)
            {
                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(this.User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return this.RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    this.ModelState.AddModelError(
                        string.Empty, "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/ChangePasswordSuccess
        public virtual ActionResult ChangePasswordSuccess()
        {
            return this.View();
        }

        public virtual ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            // return this.RedirectToAction("Index", "Home");
            return RedirectToAction("LogOn");
        }

        public virtual ActionResult LogOn()
        {
            return this.View();
        }

        // GET: /Account/GeneratePassword
        //[Authorize]
        public virtual ActionResult GeneratePassword()
        {
            return this.View();
        }

        // POST: /Account/LogOn

        [HttpPost]
        public virtual ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                //if (Membership.ValidateUser(model.UserName, model.Password))
                if (ValidateLogOn(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (this.Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return this.Redirect(returnUrl);
                    }
                    else
                    {
                        return this.RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/LogOff

        // GET: /Account/Register
        public virtual ActionResult Register()
        {
            return this.View();
        }

        // POST: /Account/Register

        [HttpPost]
        public virtual ActionResult Register(RegisterModel model)
        {
            if (this.ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Membership.CreateUser(
                    model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    return this.RedirectToAction("Index", "Home");
                }
                else
                {
                    this.ModelState.AddModelError(string.Empty, ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // POST: /Account/GeneratePassword
        [HttpPost]
        public virtual ActionResult GeneratePassword(GeneratePasswordModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.Hash = FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password, model.Format);
            }
            return this.View(model);
        }

        #endregion

        // GET: /Account/ChangePassword
        #region - Methods -

        private bool ValidateLogOn(string userName, string password)
        {
           
            if (string.IsNullOrEmpty(userName))
                ModelState.AddModelError("UserName", "User name required");

            if (string.IsNullOrEmpty(password))
                ModelState.AddModelError("Password", "Password required");

            if (ModelState.IsValid && !FormsAuthentication.Authenticate(userName, password))
                ModelState.AddModelError("_FORM", "Wrong user name or password");

            return ModelState.IsValid;
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return
                        "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return
                        "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return
                        "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return
                        "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        #endregion
    }
}
