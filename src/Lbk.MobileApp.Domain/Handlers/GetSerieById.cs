// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetSerieById.cs" company="ip-connect GmbH">
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

    public class GetSerieById
    {
        #region - Constants and Fields -

        private readonly ISerieRepository _serieRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetSerieById(ISerieRepository serieRepository)
        {
            this._serieRepository = serieRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual Serie Execute(long id)
        {
            try
            {
                return this._serieRepository.GetSerie(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveSerieExceptionMessage, ex);
            }
        }

        #endregion
    }
}
