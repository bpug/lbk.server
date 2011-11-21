// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpContextPerRequestStore.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Unity
{
    #region using directives

    using System;
    using System.Web;

    #endregion

    public class HttpContextPerRequestStore : IPerRequestStore
    {
        #region - Constructors and Destructors -

        public HttpContextPerRequestStore()
        {
            if (HttpContext.Current.ApplicationInstance != null)
            {
                // Note: We'd like to do this, but you cannot sign up for the EndRequest from
                // from this application instance as it is actually different than the one the
                // the EndRequest handler is actually invoked from.
                // HttpContext.Current.ApplicationInstance.EndRequest += this.EndRequestHandler;
            }
        }

        #endregion

        #region - Events -

        public event EventHandler EndRequest;

        #endregion

        #region - Implemented Interfaces -

        #region IPerRequestStore

        public object GetValue(object key)
        {
            return HttpContext.Current.Items[key];
        }

        public void RemoveValue(object key)
        {
            HttpContext.Current.Items.Remove(key);
        }

        public void SetValue(object key, object value)
        {
            HttpContext.Current.Items[key] = value;
        }

        #endregion

        #endregion

        #region - Methods -

        private void EndRequestHandler(object sender, EventArgs e)
        {
            EventHandler handler = this.EndRequest;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
    }
}
