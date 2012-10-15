// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetPictureById.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading;

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Model;

    #endregion

    public class BaseHandler
    {
        #region - Constants and Fields -
       
        private readonly ILocalizationRepository _localizationRepository;

        #endregion

        #region - Constructors and Destructors -

        public BaseHandler( ILocalizationRepository localizationRepository)
        {
           
            this._localizationRepository = localizationRepository;
        }

        #endregion

        protected Language DefaultLanguage
        {
            get { return _localizationRepository.GetDefaultLanguage(); }
        }

        protected bool IsDefaultLanguage
        {
            get
            {
                if (DefaultLanguage.Code == Thread.CurrentThread.CurrentCulture.IetfLanguageTag)
                {
                    return true;
                }
                return false;
            }
        }

        #region - Protected Methods -

        protected T Translate<T>(T entity, string languageCode) where T : IEntity
        {
            var @default = _localizationRepository.GetDefaultLanguage();
            if (@default.Code == Thread.CurrentThread.CurrentCulture.IetfLanguageTag)
            {
                return entity;
            }
            return _localizationRepository.TranslateTo(entity, languageCode);
        }

        protected T Translate<T>(T entity) where T : IEntity
        {
            return Translate(entity, Thread.CurrentThread.CurrentCulture.IetfLanguageTag);
        }

        protected void  UpdateTranslate<T>(T entity, string languageCode) where T : IEntity
        {
            _localizationRepository.Update(entity, languageCode);
        }

        protected void UpdateTranslate<T>(T entity) where T : IEntity
        {
             UpdateTranslate(entity, Thread.CurrentThread.CurrentCulture.IetfLanguageTag);
        }

        protected void DeleteTranslate<T>(T entity) where T : IEntity
        {
            _localizationRepository.Delete(entity);
        }

        protected void DeleteTranslate(Type type, long id)
        {
            _localizationRepository.Delete(type, id);
        }

        #endregion
    }
}
