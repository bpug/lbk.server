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

    public interface IPictureRepository
    {
        #region - Public Methods -

        void Create(Picture @picture);

        void Delete(long pictureId);

        Picture GetPicture(long pictureId);

        PagedDataList<Picture> GetPictures(PagedDataInput<Picture> pagedDataInput);

        void Update(Picture @picture);

        #endregion
    }
}
