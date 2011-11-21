// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IEventRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface IEventRepository
    {
        #region - Public Methods -

        void Create(Event @event);

        void Delete(long eventId);

        Event GetEvent(long eventId);

        PagedDataList<Event> GetEvents(PagedDataInput<Event> pagedDataInput);

        void Update(Event @event);

        #endregion
    }
}
