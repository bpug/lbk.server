// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetEventById.cs" company="ip-connect GmbH">
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

    public class GetEventById
    {
        #region - Constants and Fields -

        private readonly IEventRepository _eventRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetEventById(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual Event Execute(long id)
        {
            try
            {
                return this._eventRepository.GetEvent(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveEventExceptionMessage, ex);
            }
        }

        #endregion
    }
}
