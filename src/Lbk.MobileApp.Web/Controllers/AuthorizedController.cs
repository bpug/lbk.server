// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AuthorizedController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Controllers
{
    #region using directives

    using System;
    using System.Web.Mvc;

    using Microsoft.Practices.ServiceLocation;

    #endregion

    public class AuthorizedController : Controller
    {
        ////protected readonly IUserServices UserServices;
        #region - Constants and Fields -

        private readonly IServiceLocator _serviceLocator;

        #endregion

        ////private UserDTO _currentUser;

        ////public AuthorizedController(IUserServices userServices, IServiceLocator serviceLocator)
        #region - Constructors and Destructors -

        public AuthorizedController(IServiceLocator serviceLocator)
        {
            ////if (userServices == null)
            ////{
            ////    throw new ArgumentNullException("userServices");
            ////}
            this._serviceLocator = serviceLocator;

            ////this.UserServices = userServices;
        }

        #endregion

        ////public UserDTO CurrentUser
        ////{
        ////    get
        ////    {
        ////        return this._currentUser
        ////               ?? (this._currentUser = this.UserServices.GetUserFromIdentity(this.User.Publisher4NetIdentity()));
        ////    }
        ////}

        ////protected int CurrentUserId
        ////{
        ////    get
        ////    {
        ////        return this.User.Publisher4NetIdentity().UserId;
        ////    }
        ////}
        #region - Methods -

        protected T Using<T>() where T : class
        {
            var handler = this._serviceLocator.GetInstance<T>();
            if (handler == null)
            {
                throw new NullReferenceException("Unable to resolve type with service locator; type " + typeof(T).Name);
            }

            return handler;
        }

        #endregion
    }
}
