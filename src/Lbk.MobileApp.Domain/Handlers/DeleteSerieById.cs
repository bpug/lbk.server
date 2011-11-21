// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteSerieById.cs" company="ip-connect GmbH">
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

    public class DeleteSerieById
    {
        #region - Constants and Fields -

        private readonly ISerieRepository _serieRepository;

        #endregion

        #region - Constructors and Destructors -

        public DeleteSerieById(ISerieRepository serieRepository)
        {
            this._serieRepository = serieRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(long id)
        {
            try
            {
                this._serieRepository.Delete(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToDeleteSerieExceptionMessage, ex);
            }
        }

        #endregion
    }
}
