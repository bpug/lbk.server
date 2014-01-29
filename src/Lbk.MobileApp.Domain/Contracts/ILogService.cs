// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogService.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Domain.Contracts
{
    using System;
    using System.Collections.Generic;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Domain.Models;
    using Lbk.MobileApp.Model;

    /// <summary>
    ///   TODO: Update summary.
    /// </summary>
    public interface ILogService
    {
        IEnumerable<Log> GetAll();

        IEnumerable<StatisticsWeekModel> Get(DateTime startDate, DateTime endDate);

        PagedDataList<StatisticsWeekFlatModel> GetFlat(DateTime startDate, DateTime endDate);
    }
}