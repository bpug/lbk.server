// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerieController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Lbk.MobileApp.Domain.Resources;

namespace Lbk.MobileApp.Web.Controllers
{
    #region using directives

    using System;
    using System.Web.Mvc;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Domain.Handlers;
    using Lbk.MobileApp.Model;
    using Lbk.MobileApp.Web.Handler;
    using Lbk.MobileApp.Web.Models;
    using Lbk.MobileApp.Web.Models.Extensions;

    using Microsoft.Practices.ServiceLocation;

    #endregion

    public class SerieController : AuthorizedController
    {
        #region - Constructors and Destructors -

        public SerieController(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        #endregion

        #region - Public Methods -

        [HttpPost]
        public ActionResult Create(SerieFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<AddSerie>().Execute(model);

                return this.RedirectToAction("List", new { controller = "Question", id = model.Id });
            }

            return this.View(model);
        }

        public ActionResult Create()
        {
            return this.View(new SerieFormModel { ActivatedAt = DateTime.Now, ExpiresAt = DateTime.Now });
        }

        public ActionResult Delete(long id)
        {
            var serie = this.Using<GetSerieById>().Execute(id);

            return this.View(serie.ToFormModel());
        }

        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            this.Using<DeleteSerieById>().Execute(id);

            return this.RedirectToAction("List");
        }

        public ActionResult Detail(long id)
        {
            var serie = this.Using<GetSerieById>().Execute(id);

            return this.View(serie.ToFormModel());
        }

        [HttpPost]
        public ActionResult Edit(SerieFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<UpdateSerie>().Execute(model);

                return this.RedirectToAction("List");
            }

            return this.View(model);
        }

        public ActionResult Edit(long id)
        {
            var serie = this.Using<GetSerieById>().Execute(id);

            return this.View(serie.ToFormModel());
        }

        public ActionResult List(SerieSearchFormModel serie, PagedDataInput pagedDataInput, string btnSubmit)
        {
            var pagedDataInputOfSerie = new PagedDataInput<Serie>(pagedDataInput);
            pagedDataInputOfSerie.PageSize =
                (int)
                this.GetItemFromTempData(
                    pagedDataInputOfSerie.PageSize as object, defaultValue: 10, nullValue: 0, keyName: "PageSize");
            pagedDataInputOfSerie.SearchItem =
                this.GetItemFromTempData(
                    serie.GetValueOrDefault().ToModel(), 
                    keyPrefix: "SearchItem_", 
                    removeValue: btnSubmit == Messages.Clear);

            var series = this.Using<GetSeries>().Execute(pagedDataInputOfSerie);

            var viewModel = new GenericListViewModel<Serie, SerieSearchFormModel>();
            viewModel.Results = series;
            viewModel.SearchItem = btnSubmit == Messages.Clear
                                       ? new SerieSearchFormModel()
                                       : pagedDataInputOfSerie.SearchItem.ToSearchFormModel() ?? serie;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion
    }
}
