// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetVideoById.cs" company="ip-connect GmbH">
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

    public class GetVideoById
    {
        #region - Constants and Fields -

        private readonly IVideoRepository _videoRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetVideoById(IVideoRepository videoRepository)
        {
            this._videoRepository = videoRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual Video Execute(long id)
        {
            try
            {
                return this._videoRepository.GetVideo(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveVideoExceptionMessage, ex);
            }
        }

        #endregion
    }
}
