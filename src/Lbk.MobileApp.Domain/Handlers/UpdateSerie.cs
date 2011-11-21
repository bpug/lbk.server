// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateSerie.cs" company="ip-connect GmbH">
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

    public class UpdateSerie
    {
        #region - Constants and Fields -

        private readonly ISerieRepository _serieRepository;

        #endregion

        #region - Constructors and Destructors -

        public UpdateSerie(ISerieRepository serieRepository)
        {
            this._serieRepository = serieRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateSerieCommand serie)
        {
            try
            {
                this._serieRepository.Update(serie.ToEntity());
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToUpdateSerieExceptionMessage, ex);
            }
        }

        #endregion
    }
}
