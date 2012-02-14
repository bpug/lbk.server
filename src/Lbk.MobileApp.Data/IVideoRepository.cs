// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVideoRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface IVideoRepository
    {
        #region - Public Methods -

        void Create(Video @video);

        void Delete(long videoId);

        Video GetVideo(long videoId);

        PagedDataList<Video> GetVideos(PagedDataInput<Video> pagedDataInput);

        void Update(Video @video);

        #endregion
    }
}
