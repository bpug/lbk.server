// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Data
{
    #region using directives

    using System;
    using System.Collections.Generic;

    using Lbk.MobileApp.Model;

    #endregion

    public interface ILogRepository
    {
        IEnumerable<Log> Get(DateTime startDate, DateTime endDate);

        IEnumerable<Log> GetByDevice(DateTime startDate, DateTime endDate, DeviceType deviceType);

        IEnumerable<Log> GetAll();

        // PagedDataList<Log> GetLogs(PagedDataInput<Log> pagedDataInput);
    }
}