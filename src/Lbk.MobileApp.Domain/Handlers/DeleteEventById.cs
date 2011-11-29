// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteEventById.cs" company="ip-connect GmbH">
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

    #endregion

    public class DeleteEventById
    {
        #region - Constants and Fields -

        private readonly IEventRepository _eventRepository;

        #endregion

        #region - Constructors and Destructors -

        public DeleteEventById(IEventRepository eventRepository)
        {
            this._eventRepository = eventRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long id)
        {
            try
            {
                this._eventRepository.Delete(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToDeleteEventExceptionMessage, ex);
            }
        }

        #endregion
    }
}
