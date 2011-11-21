// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerieRepository.cs" company="ip-connect GmbH">
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

    public class SerieRepository : BaseRepository, ISerieRepository
    {
        #region - Constructors and Destructors -

        public SerieRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region ISerieRepository

        public void Create(Serie serie)
        {
            this.GetDbSet<Serie>().Add(serie);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long serieId)
        {
            var entity = this.GetDbSet<Serie>().Where(x => x.Id == serieId).Single();
            this.GetDbSet<Serie>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public Serie GetSerie(long serieId)
        {
            return this.GetDbSet<Serie>().Include("Questions").Where(x => x.Id == serieId).Single();
        }

        public PagedDataList<Serie> GetSeries(PagedDataInput<Serie> pagedDataInput)
        {
            var specification = new SeriePagedDataInputSpecification(pagedDataInput);

            return this.GetPagedDataListElements(
                pagedDataInput.PageIndex, 
                pagedDataInput.PageSize, 
                ColumnNormalizer.FixupSortColumn(pagedDataInput.Sort), 
                pagedDataInput.Ascending, 
                specification);
        }

        public void Update(Serie serie)
        {
            var entity = this.GetDbSet<Serie>().Where(x => x.Id == serie.Id).Single();

            entity.ActivatedAt = serie.ActivatedAt;
            entity.Description = serie.Description;
            entity.ExpiresAt = serie.ExpiresAt;
            entity.IsActivated = serie.IsActivated;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
