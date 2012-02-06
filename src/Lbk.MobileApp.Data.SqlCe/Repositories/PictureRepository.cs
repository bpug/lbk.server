// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureRepository.cs" company="ip-connect GmbH">
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

    public class PictureRepository : BaseRepository, IPictureRepository
    {
        #region - Constructors and Destructors -

        public PictureRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region IPictureRepository

        public void Create(Picture @picture)
        {
            this.GetDbSet<Picture>().Add(@picture);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long pictureId)
        {
            var entity = this.GetDbSet<Picture>().Where(x => x.Id == pictureId).Single();
            this.GetDbSet<Picture>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public Picture GetPicture(long pictureId)
        {
            return this.GetDbSet<Picture>().Where(x => x.Id == pictureId).Single();
        }

        public PagedDataList<Picture> GetPictures(PagedDataInput<Picture> pagedDataInput)
        {
            var specification = new PicturePagedDataInputSpecification(pagedDataInput);

            return this.GetPagedDataListElements(
                pagedDataInput.PageIndex, 
                pagedDataInput.PageSize, 
                ColumnNormalizer.FixupSortColumn(pagedDataInput.Sort), 
                pagedDataInput.Ascending, 
                specification);
        }

        public void Update(Picture @picture)
        {
            var entity = this.GetDbSet<Picture>().Where(x => x.Id == @picture.Id).Single();

            entity.Description = @picture.Description;
            entity.FileName = @picture.FileName;
            entity.Link = @picture.Link;
            entity.SortOrder = @picture.SortOrder;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
