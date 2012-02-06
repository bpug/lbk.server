// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPicture.cs" company="ip-connect GmbH">
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

    public class AddPicture
    {
        #region - Constants and Fields -

        private readonly IPictureRepository _pictureRepository;

        #endregion

        #region - Constructors and Destructors -

        public AddPicture(IPictureRepository pictureRepository)
        {
            this._pictureRepository = pictureRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreatePictureCommand @picture)
        {
            if (@picture == null)
            {
                throw new ArgumentNullException("picture");
            }

            try
            {
                var entity = @picture.ToEntity();
                this._pictureRepository.Create(entity);

                @picture.Id = entity.Id;
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToAddPictureExceptionMessage, ex);
            }
        }

        #endregion
    }
}
