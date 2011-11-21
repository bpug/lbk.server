// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddSerie.cs" company="ip-connect GmbH">
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

    public class AddSerie
    {
        #region - Constants and Fields -

        private readonly ISerieRepository _serieRepository;

        #endregion

        #region - Constructors and Destructors -

        public AddSerie(ISerieRepository serieRepository)
        {
            this._serieRepository = serieRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual void Execute(ICreateSerieCommand serie)
        {
            if (serie == null)
            {
                throw new ArgumentNullException("serie");
            }

            try
            {
                var entity = serie.ToEntity();
                this._serieRepository.Create(entity);

                serie.Id = entity.Id;
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToAddSerieExceptionMessage, ex);
            }
        }

        #endregion
    }
}
