// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddEvent.cs" company="ip-connect GmbH">
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

    public class AddEvent
    {
        #region - Constants and Fields -

        private readonly IEventRepository _eventRepository;

        #endregion

        #region - Constructors and Destructors -

        public AddEvent(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateEventCommand @event)
        {
            if (@event == null)
            {
                throw new ArgumentNullException("event");
            }

            try
            {
                var entity = @event.ToEntity();
                this._eventRepository.Create(entity);

                @event.Id = entity.Id;
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToAddEventExceptionMessage, ex);
            }
        }

        #endregion
    }
}
