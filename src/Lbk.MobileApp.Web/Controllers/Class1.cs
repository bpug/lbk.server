// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class1.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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

    using Microsoft.Practices.ServiceLocation;

    #endregion

    public class EventController : AuthorizedController
    {
        #region - Constructors and Destructors -

        public EventController(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        #endregion

        #region - Public Methods -

        [HttpPost]
        public ActionResult Create(EventFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<AddEvent>().Execute(model);

                return this.RedirectToAction("List");
            }

            return this.View(model);
        }

        public ActionResult Create()
        {
            return this.View(new EventFormModel { Date = DateTime.Now });
        }

        public ActionResult Delete(long id)
        {
            var @event = this.Using<GetEventById>().Execute(id);

            return this.View(EventSearchFormModelExtensions.ToFormModel(@event));
        }

        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            this.Using<DeleteEventById>().Execute(id);

            return this.RedirectToAction("List");
        }

        public ActionResult Detail(long id)
        {
            var @event = this.Using<GetEventById>().Execute(id);

            return this.View(EventSearchFormModelExtensions.ToFormModel(@event));
        }

        [HttpPost]
        public ActionResult Edit(EventFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<UpdateEvent>().Execute(model);

                return this.RedirectToAction("List");
            }

            return this.View(model);
        }

        public ActionResult Edit(long id)
        {
            var @event = this.Using<GetEventById>().Execute(id);

            return this.View(EventSearchFormModelExtensions.ToFormModel(@event));
        }

        public ActionResult List(EventSearchFormModel @event, PagedDataInput pagedDataInput, string btnSubmit)
        {
            var pagedDataInputOfEvent = new PagedDataInput<Event>(pagedDataInput);
            pagedDataInputOfEvent.PageSize =
                (int)
                this.GetItemFromTempData(
                    pagedDataInputOfEvent.PageSize as object, defaultValue: 10, nullValue: 0, keyName: "PageSize");
            pagedDataInputOfEvent.SearchItem =
                this.GetItemFromTempData(
                    EventSearchFormModelExtensions.ToModel(@event.GetValueOrDefault()), 
                    keyPrefix: "SearchItem_", 
                    removeValue: btnSubmit == "Clear");

            var events = this.Using<GetEvents>().Execute(pagedDataInputOfEvent);

            var viewModel = new GenericListViewModel<Event, EventSearchFormModel>();
            viewModel.Results = events;
            viewModel.SearchItem = btnSubmit == "Clear"
                                       ? new EventSearchFormModel()
                                       : EventSearchFormModelExtensions.ToSearchFormModel(
                                           pagedDataInputOfEvent.SearchItem) ?? @event;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion
    }
}
