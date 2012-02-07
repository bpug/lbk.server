// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdatePicture.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Extensions;
    using Lbk.MobileApp.Domain.Resources;

    #endregion

    public class UpdatePicture
    {
        #region - Constants and Fields -

        private readonly IPictureRepository _pictureRepository;

        #endregion

        #region - Constructors and Destructors -

        public UpdatePicture(IPictureRepository pictureRepository)
        {
            this._pictureRepository = pictureRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreatePictureCommand @picture)
        {
            try
            {
                this._pictureRepository.Update(@picture.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToUpdatePictureExceptionMessage, ex);
            }
        }

        #endregion
    }
}
