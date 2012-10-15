// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPictureRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface ILanguageRepository
    {
        #region - Public Methods -

        void Create(Language language);

        void Delete(long languageId);

        Language GetLanguage(long languageId);

        void Update(Language language);

        #endregion
    }
}
