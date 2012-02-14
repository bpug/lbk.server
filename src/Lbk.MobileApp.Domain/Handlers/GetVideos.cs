// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetVideos.cs" company="ip-connect GmbH">
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

    public class GetVideos
    {
        #region - Constants and Fields -

        private readonly IVideoRepository _videoRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetVideos(IVideoRepository videoRepository)
        {
            this._videoRepository = videoRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual PagedDataList<Video> Execute(PagedDataInput<Video> pagedDataInput)
        {
            try
            {
                return this._videoRepository.GetVideos(pagedDataInput);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveVideoExceptionMessage, ex);
            }
        }

        #endregion
    }
}
