// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogService.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Core.Extensions;
    using Lbk.MobileApp.Data;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Models;
    using Lbk.MobileApp.Model;

    /// <summary>
    ///   TODO: Update summary.
    /// </summary>
    public class LogService : ILogService
    {
        private readonly ILogRepository repository;

        public LogService(ILogRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<StatisticsWeekModel> Get(DateTime startDate, DateTime endDate, DeviceType deviceType)
        {
            var logs = this.repository.GetByDevice(startDate, endDate.FullDay(), deviceType);
            var groupedByWeek = logs.GroupBy(
                i => new
                    {
                        Year = i.InsertTime.YearForIso8601Week(), 
                        Week = i.InsertTime.Iso8601WeekOfYear(), 
                        Type = i.Event.Description
                    }).Select(
                        g => new StatisticsWeekModel
                            {
                                Week = g.Key.Week, 
                                Type = g.Key.Type, 
                                Year = g.Key.Year, 
                                Count = g.Count(), 
                            });
            return groupedByWeek;
        }

        public PagedDataList<StatisticsWeekFlatModel> GetFlatByDevice(
            DateTime startDate, DateTime endDate, DeviceType deviceType)
        {
            var logs = this.Get(startDate, endDate, deviceType);
            var flats = this.TransformateToFlat(logs);
            var paged = flats.ToPagedDataList(0, int.MaxValue);
            return paged;
        }

        private IEnumerable<StatisticsWeekFlatModel> TransformateToFlat(
            IEnumerable<StatisticsWeekModel> statisticsWeekModels)
        {
            var groupedByweek = statisticsWeekModels.GroupBy(
                p => new
                    {
                        p.Week, 
                        p.Year
                    }).OrderBy(p => p.Key.Year).ThenBy(p => p.Key.Week);

            var models = new List<StatisticsWeekFlatModel>();

            foreach (var row in groupedByweek)
            {
                var model = new StatisticsWeekFlatModel
                    {
                        Week = row.Key.Week, 
                        Year = row.Key.Year
                    };

                foreach (var column in row)
                {
                    switch (column.Type)
                    {
                        case "Tageskarte abgerufen":
                            model.Tageskarte = column.Count;
                            break;
                        case "Quiz gestartet":
                            model.Quiz = column.Count;
                            break;
                        case "Events abgerufen":
                            model.Events = column.Count;
                            break;
                        case "Reservierung angefragt":
                            model.Reservierung = column.Count;
                            break;
                        case "Reservierung vom Gast bestätigt":
                            model.ReservierungGast = column.Count;
                            break;
                        case "Bilder abgerufen":
                            model.Bilder = column.Count;
                            break;
                        case "Videos abgerufen":
                            model.Videos = column.Count;
                            break;
                    }
                }

                models.Add(model);
            }

            return models;
        }

        // private IEnumerable<StatisticsWeekFlatModel> GetPivotFlat(DateTime startDate, DateTime endDate)
        // {
        // var logs = this.Get(startDate, endDate, DeviceType.All);

        // var pivot = logs.Pivot(p => p.Week, p => p.Type, p => p.First().Count);

        // // var pivot2 = logs.Pivot2(p => p.Week, p => p.Type, p => p.Sum(s => s.Count));
        // var models = new List<StatisticsWeekFlatModel>();

        // foreach (var row in pivot)
        // {
        // var model = new StatisticsWeekFlatModel
        // {
        // Week = row.Key
        // };
        // foreach (var column in row.Value)
        // {
        // switch (column.Key)
        // {
        // case "Tageskarte abgerufen":
        // model.Tageskarte = column.Value;
        // break;
        // case "Quiz gestartet":
        // model.Quiz = column.Value;
        // break;
        // case "Events abgerufen":
        // model.Events = column.Value;
        // break;
        // case "Reservierung angefragt":
        // model.Reservierung = column.Value;
        // break;
        // case "Reservierung vom Gast bestätigt":
        // model.ReservierungGast = column.Value;
        // break;
        // case "Bilder abgerufen":
        // model.Bilder = column.Value;
        // break;
        // case "Videos abgerufen":
        // model.Videos = column.Value;
        // break;
        // }
        // }

        // models.Add(model);
        // }

        // return models;
        // }
    }
}