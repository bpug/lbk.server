// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetSeries.cs" company="ip-connect GmbH">
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

    public class GetSeries
    {
        #region - Constants and Fields -

        private readonly ISerieRepository _serieRepository;

        #endregion

        #region - Constructors and Destructors -

        public GetSeries(ISerieRepository serieRepository)
        {
            this._serieRepository = serieRepository;
        }

        #endregion

        #region - Public Methods -

        public virtual PagedDataList<Serie> Execute(PagedDataInput<Serie> pagedDataInput)
        {
            try
            {
                return this._serieRepository.GetSeries(pagedDataInput);
            }
            catch (InvalidOperationException ex)
            {
                throw new BusinessServicesException(Messages.UnableToRetrieveSerieExceptionMessage, ex);
            }
        }

        #endregion
    }
}
