// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeletePictureById.cs" company="ip-connect GmbH">
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

    #endregion

    public class DeletePictureById
    {
        #region - Constants and Fields -

        private readonly IPictureRepository _pictureRepository;

        #endregion

        #region - Constructors and Destructors -

        public DeletePictureById(IPictureRepository pictureRepository)
        {
            this._pictureRepository = pictureRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long id)
        {
            try
            {
                this._pictureRepository.Delete(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToDeletePictureExceptionMessage, ex);
            }
        }

        #endregion
    }
}
