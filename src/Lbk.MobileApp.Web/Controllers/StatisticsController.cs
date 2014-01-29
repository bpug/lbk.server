// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticsController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Lbk.MobileApp.Domain.Contracts;
    using Lbk.MobileApp.Domain.Models;
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

        public virtual ActionResult Index(StatisticsSearchFormModel search)
        {
            //var startDate = new DateTime(2012, 12, 31);
            //var endDate = new DateTime(2013, 7, 1, 23, 59, 59);

            var endDate = search.EndDate.GetValueOrDefault().AddHours(23).AddMinutes(59).AddSeconds(59);

            var logs = this.logService.GetFlat(search.StartDate.GetValueOrDefault(), endDate);

            var viewModel = new GenericListViewModel<StatisticsWeekFlatModel, StatisticsSearchFormModel>
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
    }
}