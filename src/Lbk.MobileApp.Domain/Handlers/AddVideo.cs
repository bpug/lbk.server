// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddVideo.cs" company="ip-connect GmbH">
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

    public class AddVideo
    {
        #region - Constants and Fields -

        private readonly IVideoRepository _videoRepository;

        #endregion

        #region - Constructors and Destructors -

        public AddVideo(IVideoRepository videoRepository)
        {
            this._videoRepository = videoRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateVideoCommand @video)
        {
            if (@video == null)
            {
                throw new ArgumentNullException("video");
            }

            try
            {
                var entity = @video.ToEntity();
                this._videoRepository.Create(entity);

                @video.Id = entity.Id;
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToAddVideoExceptionMessage, ex);
            }
        }

        #endregion
    }
}
