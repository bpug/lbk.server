// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VideoController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Lbk.MobileApp.Domain.Resources;

namespace Lbk.MobileApp.Web.Controllers
{
    #region using directives

    using System.Web.Mvc;

    using Lbk.MobileApp.Core;
    using Lbk.MobileApp.Domain.Handlers;
    using Lbk.MobileApp.Model;
    using Lbk.MobileApp.Web.Handler;
    using Lbk.MobileApp.Web.Models;
    using Lbk.MobileApp.Web.Models.Extensions;

    using Microsoft.Practices.ServiceLocation;

    #endregion

    public partial class VideoController : AuthorizedController
    {
        #region - Constructors and Destructors -

        public VideoController(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        #endregion

        #region - Public Methods -

        [HttpPost]
        public virtual ActionResult Create(VideoFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<AddVideo>().Execute(model);

                return this.RedirectToAction("List");
            }

            return this.View(model);
        }

        public virtual ActionResult Create()
        {
            return this.View(new VideoFormModel());
        }

        public virtual ActionResult Delete(long id)
        {
            var @video = this.Using<GetVideoById>().Execute(id);

            return this.View(@video.ToFormModel());
        }

        [HttpPost]
        public virtual ActionResult Delete(long id, object dummy)
        {
            this.Using<DeleteVideoById>().Execute(id);

            return this.RedirectToAction("List");
        }

        public virtual ActionResult Detail(long id)
        {
            var @video = this.Using<GetVideoById>().Execute(id);

            return this.View(@video.ToFormModel());
        }

        [HttpPost]
        public virtual ActionResult Edit(VideoFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<UpdateVideo>().Execute(model);

                return this.RedirectToAction("List");
            }

            return this.View(model);
        }

        public virtual ActionResult Edit(long id)
        {
            var @video = this.Using<GetVideoById>().Execute(id);

            return this.View(@video.ToFormModel());
        }

        public virtual ActionResult List(VideoSearchFormModel @video, PagedDataInput pagedDataInput, string btnSubmit)
        {
            var pagedDataInputOfVideo = new PagedDataInput<Video>(pagedDataInput);
            pagedDataInputOfVideo.PageSize =
                (int)
                this.GetItemFromTempData(
                    pagedDataInputOfVideo.PageSize as object, defaultValue: 10, nullValue: 0, keyName: "PageSize");
            pagedDataInputOfVideo.SearchItem =
                this.GetItemFromTempData(
                    @video.GetValueOrDefault().ToModel(), 
                    keyPrefix: "SearchItem_", 
                    removeValue: btnSubmit == Messages.Clear);

            var videos = this.Using<GetVideos>().Execute(pagedDataInputOfVideo);

            var viewModel = new GenericListViewModel<Video, VideoSearchFormModel>();
            viewModel.Results = videos;
            viewModel.SearchItem = btnSubmit == Messages.Clear
                                       ? new VideoSearchFormModel()
                                       : pagedDataInputOfVideo.SearchItem.ToSearchFormModel()
                                         ?? @video;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion
    }
}
