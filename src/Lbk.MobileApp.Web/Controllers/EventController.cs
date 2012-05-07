// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using System.IO;
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
                if (Upload(model))
                {
                    this.Using<AddEvent>().Execute(model);
                    return this.RedirectToAction("List");
                }
                return this.View(model);
            }

            return this.View(model);
        }

        public ActionResult Create()
        {
            return
                this.View(
                    new EventFormModel
                        {
                            ActivatedAt = DateTime.Now, 
                            DateOrder = DateTime.Now, 
                            ExpiresAt = DateTime.Now, 
                            Date = DateTime.Now.ToString("D")
                        });
        }

        public ActionResult Delete(long id)
        {
            var @event = this.Using<GetEventById>().Execute(id);

            return this.View(@event.ToFormModel());
        }

        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            var @event = this.Using<GetEventById>().Execute(id);
            var model = @event.ToFormModel();
            if (DeleteFile(model))
            {
                this.Using<DeleteEventById>().Execute(id);
                return this.RedirectToAction("List");
            }
            return this.View(model);
        }

        public ActionResult Detail(long id)
        {
            var @event = this.Using<GetEventById>().Execute(id);

            return this.View(@event.ToFormModel());
        }

        [HttpPost]
        public ActionResult Edit(EventFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                if (Upload(model))
                {
                    this.Using<UpdateEvent>().Execute(model);
                    return this.RedirectToAction("List");
                }
                return this.View(model);
            }
            return this.View(model);
        }

        public ActionResult Edit(long id)
        {
            var @event = this.Using<GetEventById>().Execute(id);

            return this.View(@event.ToFormModel());
        }

        public ActionResult List(EventSearchFormModel @event, PagedDataInput pagedDataInput, string btnSubmit)
        {
            var pagedDataInputOfEvent = new PagedDataInput<Event>(pagedDataInput);
            //var pagedDataInputOfEvent = new PagedDataInput<EventFormModel>(pagedDataInput);
            pagedDataInputOfEvent.PageSize =
                (int)
                this.GetItemFromTempData(
                    pagedDataInputOfEvent.PageSize as object, defaultValue: 10, nullValue: 0, keyName: "PageSize");
            pagedDataInputOfEvent.SearchItem =
                this.GetItemFromTempData(@event.GetValueOrDefault().ToModel(), 
                    keyPrefix: "SearchItem_",
                    removeValue: btnSubmit == Messages.Clear);

            var events = this.Using<GetEvents>().Execute(pagedDataInputOfEvent).ToFormModel();

            //var viewModel = new GenericListViewModel<Event, EventSearchFormModel>();
            var viewModel = new GenericListViewModel<EventFormModel, EventSearchFormModel>();
            viewModel.Results = events;
            viewModel.SearchItem = btnSubmit == Messages.Clear
                                       ? new EventSearchFormModel()
                                       : pagedDataInputOfEvent.SearchItem.ToSearchFormModel()
                                         ?? @event;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion

        private bool Upload(EventFormModel model)
        {
            if (model.Thumbnail != null)
            {
                DeleteFile(model);
                try
                {
                    var path = ConfigurationManager.AppSettings["EventThumbnailServerBasePath"];
                    string filename = Path.GetFileName(model.Thumbnail.FileName);
                    if (filename != null)
                    {
                        model.ThumbnailName = filename;
                        model.Thumbnail.SaveAs(Path.Combine(path, filename));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("Thumbnail", ex.Message);
                }
            }

            return ModelState.IsValid;
        }

        private bool DeleteFile(EventFormModel model)
        {
            if (!string.IsNullOrEmpty(model.ThumbnailName))
            {
                try
                {
                    var path = ConfigurationManager.AppSettings["EventThumbnailServerBasePath"];
                    System.IO.File.Delete(Path.Combine(path, model.ThumbnailName));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return ModelState.IsValid;
        }
    }
}
