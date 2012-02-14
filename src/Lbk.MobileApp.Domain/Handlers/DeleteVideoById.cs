// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteVideoById.cs" company="ip-connect GmbH">
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

    public class DeleteVideoById
    {
        #region - Constants and Fields -

        private readonly IVideoRepository _videoRepository;

        #endregion

        #region - Constructors and Destructors -

        public DeleteVideoById(IVideoRepository videoRepository)
        {
            this._videoRepository = videoRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long id)
        {
            try
            {
                this._videoRepository.Delete(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToDeleteVideoExceptionMessage, ex);
            }
        }

        #endregion
    }
}
