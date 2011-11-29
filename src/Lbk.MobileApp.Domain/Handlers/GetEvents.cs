// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetEvents.cs" company="ip-connect GmbH">
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

    public class GetEvents
    {
        #region - Constants and Fields -

        private readonly IEventRepository _eventRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetEvents(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual PagedDataList<Event> Execute(PagedDataInput<Event> pagedDataInput)
        {
            try
            {
                return this._eventRepository.GetEvents(pagedDataInput);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveEventExceptionMessage, ex);
            }
        }

        #endregion
    }
}
