// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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

    public class PictureController : AuthorizedController
    {
        #region - Constructors and Destructors -

        public PictureController(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        #endregion

        #region - Public Methods -

        [HttpPost]
        public ActionResult Create(PictureFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<AddPicture>().Execute(model);

                return this.RedirectToAction("List");
            }

            return this.View(model);
        }

        public ActionResult Create()
        {
            return this.View(new PictureFormModel());
        }

        public ActionResult Delete(long id)
        {
            var @picture = this.Using<GetPictureById>().Execute(id);

            return this.View(PictureModelExtensions.ToFormModel(@picture));
        }

        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            this.Using<DeletePictureById>().Execute(id);

            return this.RedirectToAction("List");
        }

        public ActionResult Detail(long id)
        {
            var @picture = this.Using<GetPictureById>().Execute(id);

            return this.View(PictureModelExtensions.ToFormModel(@picture));
        }

        [HttpPost]
        public ActionResult Edit(PictureFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<UpdatePicture>().Execute(model);

                return this.RedirectToAction("List");
            }

            return this.View(model);
        }

        public ActionResult Edit(long id)
        {
            var @picture = this.Using<GetPictureById>().Execute(id);

            return this.View(PictureModelExtensions.ToFormModel(@picture));
        }

        public ActionResult List(PictureSearchFormModel @picture, PagedDataInput pagedDataInput, string btnSubmit)
        {
            var pagedDataInputOfPicture = new PagedDataInput<Picture>(pagedDataInput);
            pagedDataInputOfPicture.PageSize =
                (int)
                this.GetItemFromTempData(
                    pagedDataInputOfPicture.PageSize as object, defaultValue: 10, nullValue: 0, keyName: "PageSize");
            pagedDataInputOfPicture.SearchItem =
                this.GetItemFromTempData(
                    PictureModelExtensions.ToModel(@picture.GetValueOrDefault()), 
                    keyPrefix: "SearchItem_", 
                    removeValue: btnSubmit == "Clear");

            var pictures = this.Using<GetPictures>().Execute(pagedDataInputOfPicture);

            var viewModel = new GenericListViewModel<Picture, PictureSearchFormModel>();
            viewModel.Results = pictures;
            viewModel.SearchItem = btnSubmit == "Clear"
                                       ? new PictureSearchFormModel()
                                       : PictureModelExtensions.ToSearchFormModel(pagedDataInputOfPicture.SearchItem)
                                         ?? @picture;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion
    }
}
