// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogRepository.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Data.SqlCe.Repositories
{
    #region using directives

    using System;
    using System.Collections.Generic;
    using System.Data.Objects.SqlClient;
    using System.Linq;

    using Lbk.MobileApp.Model;

    #endregion

    public class LogRepository : BaseRepository, ILogRepository
    {
        public LogRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IEnumerable<Log> Get(DateTime startDate, DateTime endDate)
        {
            var logs =
                this.GetDbSet<Log>().Include("Type").Where(p => p.InsertTime >= startDate && p.InsertTime <= endDate);
            return logs;
        }

        public IEnumerable<Log> GetAll()
        {
            return this.GetDbSet<Log>();
        }

        public IEnumerable<Log> GetByDate(DateTime startDate, DateTime endDate)
        {
            var logs =
                this.GetDbSet<Log>().Include("Type").Where(p => p.InsertTime >= startDate && p.InsertTime <= endDate);

            var groupedByWeek = logs.GroupBy(
                i => new
                    {
                        Week = SqlFunctions.DatePart("wk", i.InsertTime), 
                        i.InsertTime.Year, 
                        i.Type
                    }).Select(
                        g => new
                            {
                                g.Key.Week, 
                                g.Key.Year, 
                                g.Key.Type.Description, 
                                Count = g.Count()
                            });
            return logs;
        }
    }
}