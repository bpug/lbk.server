// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPictureRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface ILocalizationRepository
    {
        #region - Public Methods -

        T TranslateTo<T>(T entity, string languageCode) where T : IEntity;
        void Update<T>(T entity, string languageCode) where T : IEntity;
        void Delete<T>(T entity) where T :  IEntity;
        void Delete(Type type, long entityId);
        Language GetDefaultLanguage();

        #endregion
    }
}
