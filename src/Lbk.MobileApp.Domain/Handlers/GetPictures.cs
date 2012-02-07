// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetPictures.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Model;

    #endregion

    public class GetPictures
    {
        #region - Constants and Fields -

        private readonly IPictureRepository _pictureRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetPictures(IPictureRepository pictureRepository)
        {
            this._pictureRepository = pictureRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual PagedDataList<Picture> Execute(PagedDataInput<Picture> pagedDataInput)
        {
            try
            {
                return this._pictureRepository.GetPictures(pagedDataInput);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrievePictureExceptionMessage, ex);
            }
        }

        #endregion
    }
}
