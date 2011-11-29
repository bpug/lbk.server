// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateEvent.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Handlers
{
    #region using directives

    using System;

    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Extensions;
    using Lbk.MobileApp.Domain.Resources;

    #endregion

    public class UpdateEvent
    {
        #region - Constants and Fields -

        private readonly IEventRepository _eventRepository;

        #endregion

        #region - Constructors and Destructors -

        public UpdateEvent(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateEventCommand @event)
        {
            try
            {
                this._eventRepository.Update(@event.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToUpdateEventExceptionMessage, ex);
            }
        }

        #endregion
    }
}
