// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdatePicture.cs" company="ip-connect GmbH">
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
    using Lbk.MobileApp.Domain.Extensions;
    using Lbk.MobileApp.Domain.Resources;

    #endregion

    public class UpdatePicture : BaseHandler
    {
        #region - Constants and Fields -

        private readonly IPictureRepository _pictureRepository;

        #endregion

        #region - Constructors and Destructors -

        public UpdatePicture(IPictureRepository pictureRepository, ILocalizationRepository localizationRepository)
            : base(localizationRepository)
        {
            this._pictureRepository = pictureRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreatePictureCommand @picture)
        {
            try
            {

                if (IsDefaultLanguage)
                {
                    this._pictureRepository.Update(@picture.ToEntity());
                }
                else
                {
                    UpdateTranslate(@picture.ToEntity());
                }
                
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToUpdatePictureExceptionMessage, ex);
            }
        }

        #endregion
    }
}
