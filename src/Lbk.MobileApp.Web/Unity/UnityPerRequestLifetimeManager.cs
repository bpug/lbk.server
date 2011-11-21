// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityPerRequestLifetimeManager.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Unity
{
    #region using directives

    using System;

    using Microsoft.Practices.Unity;

    #endregion

    public class UnityPerRequestLifetimeManager : LifetimeManager, IDisposable
    {
        #region - Constants and Fields -

        private readonly IPerRequestStore _contextStore;

        private readonly Guid _key = Guid.NewGuid();

        #endregion

        #region - Constructors and Destructors -

        public UnityPerRequestLifetimeManager(IPerRequestStore contextStore)
        {
            this._contextStore = contextStore;
            this._contextStore.EndRequest += this.EndRequestHandler;
        }

        #endregion

        #region - Public Methods -

        public override object GetValue()
        {
            return this._contextStore.GetValue(this._key);
        }

        public override void RemoveValue()
        {
            var oldValue = this._contextStore.GetValue(this._key);
            this._contextStore.RemoveValue(this._key);

            var disposable = oldValue as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }

        public override void SetValue(object newValue)
        {
            this._contextStore.SetValue(this._key, newValue);
        }

        #endregion

        #region - Implemented Interfaces -

        #region IDisposable

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #endregion

        #region - Methods -

        protected virtual void Dispose(bool disposing)
        {
            this.RemoveValue();
        }

        private void EndRequestHandler(object sender, EventArgs e)
        {
            this.RemoveValue();
        }

        #endregion
    }
}
