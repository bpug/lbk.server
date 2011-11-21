// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISerieRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Data
{
    #region using directives

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Model;

    #endregion

    public interface ISerieRepository
    {
        #region - Public Methods -

        void Create(Serie serie);

        void Delete(long serieId);

        Serie GetSerie(long serieId);

        PagedDataList<Serie> GetSeries(PagedDataInput<Serie> pagedDataInput);

        void Update(Serie serie);

        #endregion
    }
}
