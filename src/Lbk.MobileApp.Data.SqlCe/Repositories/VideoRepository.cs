// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data.SqlCe.Repositories
{
    #region using directives

    using System.Data;
    using System.Linq;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Data.Core;
    using Lbk.MobileApp.Data.SqlCe.Repositories.Specifications;
    using Lbk.MobileApp.Model;

    #endregion

    public class VideoRepository : BaseRepository, IVideoRepository
    {
        #region - Constructors and Destructors -

        public VideoRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region IVideoRepository

        public void Create(Video @video)
        {
            this.GetDbSet<Video>().Add(@video);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long videoId)
        {
            var entity = this.GetDbSet<Video>().Single(x => x.Id == videoId);
            this.GetDbSet<Video>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public Video GetVideo(long videoId)
        {
            return this.GetDbSet<Video>().Single(x => x.Id == videoId);
        }

        public PagedDataList<Video> GetVideos(PagedDataInput<Video> pagedDataInput)
        {
            var specification = new VideoPagedDataInputSpecification(pagedDataInput);

            return this.GetPagedDataListElements(
                pagedDataInput.PageIndex, 
                pagedDataInput.PageSize, 
                ColumnNormalizer.FixupSortColumn(pagedDataInput.Sort), 
                pagedDataInput.Ascending, 
                specification);
        }

        public void Update(Video @video)
        {
            var entity = this.GetDbSet<Video>().Single(x => x.Id == @video.Id);

            entity.Description = @video.Description;
            entity.FileName = @video.FileName;
            entity.Link = @video.Link;
            entity.SortOrder = @video.SortOrder;
            entity.ThumbnailLink = @video.ThumbnailLink;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
