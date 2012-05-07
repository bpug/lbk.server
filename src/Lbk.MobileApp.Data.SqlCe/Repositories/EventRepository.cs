// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventRepository.cs" company="ip-connect GmbH">
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

    public class EventRepository : BaseRepository, IEventRepository
    {
        #region - Constructors and Destructors -

        public EventRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion

        #region - Implemented Interfaces -

        #region IEventRepository

        public void Create(Event @event)
        {
            this.GetDbSet<Event>().Add(@event);

            this.UnitOfWork.SaveChanges();
        }

        public void Delete(long eventId)
        {
            var entity = this.GetDbSet<Event>().Where(x => x.Id == eventId).Single();
            this.GetDbSet<Event>().Remove(entity);

            this.UnitOfWork.SaveChanges();
        }

        public Event GetEvent(long eventId)
        {
            return this.GetDbSet<Event>().Where(x => x.Id == eventId).Single();
        }

        public PagedDataList<Event> GetEvents(PagedDataInput<Event> pagedDataInput)
        {
            var specification = new EventPagedDataInputSpecification(pagedDataInput);

            return this.GetPagedDataListElements(
                pagedDataInput.PageIndex, 
                pagedDataInput.PageSize, 
                ColumnNormalizer.FixupSortColumn(pagedDataInput.Sort), 
                pagedDataInput.Ascending, 
                specification);
        }

        public void Update(Event @event)
        {
            var entity = this.GetDbSet<Event>().Where(x => x.Id == @event.Id).Single();

            entity.ActivatedAt = @event.ActivatedAt;
            entity.Date = @event.Date;
            entity.DateOrder = @event.DateOrder;
            entity.Description = @event.Description;
            entity.ExpiresAt = @event.ExpiresAt;
            entity.IsActivated = @event.IsActivated;
            entity.Title = @event.Title;
            entity.ReservationLink = @event.ReservationLink;
            entity.ThumbnailLink = @event.ThumbnailLink;
            entity.ThumbnailName = @event.ThumbnailName;

            this.SetEntityState(entity, entity.Id == 0 ? EntityState.Added : EntityState.Modified);

            this.UnitOfWork.SaveChanges();
        }

        #endregion

        #endregion
    }
}
