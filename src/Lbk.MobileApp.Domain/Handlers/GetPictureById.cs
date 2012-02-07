// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetPictureById.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Resources;
    using Lbk.MobileApp.Model;

    #endregion

    public class GetPictureById
    {
        #region - Constants and Fields -

        private readonly IPictureRepository _pictureRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetPictureById(IPictureRepository pictureRepository)
        {
            this._pictureRepository = pictureRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual Picture Execute(long id)
        {
            try
            {
                return this._pictureRepository.GetPicture(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrievePictureExceptionMessage, ex);
            }
        }

        #endregion
    }
}
