// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateVideo.cs" company="ip-connect GmbH">
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

    public class UpdateVideo
    {
        #region - Constants and Fields -

        private readonly IVideoRepository _videoRepository;

        #endregion

        #region - Constructors and Destructors -

        public UpdateVideo(IVideoRepository videoRepository)
        {
            this._videoRepository = videoRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateVideoCommand @video)
        {
            try
            {
                this._videoRepository.Update(@video.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToUpdateVideoExceptionMessage, ex);
            }
        }

        #endregion
    }
}
