// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticsController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Web.Controllers
{
    using System.Web.Mvc;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Models;
    using Lbk.MobileApp.Domain.Reports;
    using Lbk.MobileApp.Web.Models;

    using Microsoft.Practices.ServiceLocation;

    public partial class StatisticsController : AuthorizedController
    {
        private readonly ILogService logService;

        public StatisticsController(IServiceLocator serviceLocator, ILogService logService)
            : base(serviceLocator)
        {
            this.logService = logService;
        }

        public virtual ActionResult Index()
        {
            var viewModel = new GenericListViewModel<StatisticsWeekFlatModel, StatisticsFormModel>
            {
               SearchItem = new StatisticsFormModel(),
               Results = new PagedDataList<StatisticsWeekFlatModel>()
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public virtual ActionResult Index(StatisticsFormModel search)
        {
            var logs = this.logService.GetFlatByDevice(
                search.StartDate.GetValueOrDefault(), search.EndDate.GetValueOrDefault(), search.DeviceType);

            var viewModel = new GenericListViewModel<StatisticsWeekFlatModel, StatisticsFormModel>
                {
                    Results = logs, 
                    SearchItem = search
                };
            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView(MVC.Statistics.Views._grid, logs);
            }

            return this.View(viewModel);
        }

        public virtual ActionResult GetCsv(StatisticsFormModel search)
        {
            var logs = this.logService.GetFlatByDevice(
                search.StartDate.GetValueOrDefault(), search.EndDate.GetValueOrDefault(), search.DeviceType);

            var exprort = new CsvExport<StatisticsWeekFlatModel>(logs);
            var buffer = exprort.ExportToBytes();
            return this.File(buffer, @"text/csv", "statistics.csv");
        }
       
    }
}