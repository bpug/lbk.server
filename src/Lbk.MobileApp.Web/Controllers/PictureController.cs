// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PictureController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.IO;
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
                Validate(model);

                if (Upload(model))
                {
                    this.Using<AddPicture>().Execute(model);
                    return this.RedirectToAction("List");
                }
                return this.View(model);
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
            var @picture = this.Using<GetPictureById>().Execute(id);
            var model = PictureModelExtensions.ToFormModel(@picture);
            if (DeleteFile(model))
            {
                this.Using<DeletePictureById>().Execute(id);
                return this.RedirectToAction("List");
            }
            return this.View(model);
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
                Validate(model);
                
                //if (model.File == null)
                //{
                //    if (!DeleteFile(model))
                //    {
                //        return this.View(model);
                //    }
                //}

                if (Upload(model))
                {
                    this.Using<UpdatePicture>().Execute(model);
                    return this.RedirectToAction("List");
                }
                return this.View(model);
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
                    removeValue: btnSubmit == Messages.Clear);

            var pictures = this.Using<GetPictures>().Execute(pagedDataInputOfPicture);

            var viewModel = new GenericListViewModel<Picture, PictureSearchFormModel>();
            viewModel.Results = pictures;
            viewModel.SearchItem = btnSubmit == Messages.Clear
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

        private bool Upload(PictureFormModel model)
        {
           if (model.File != null)
            {
                DeleteFile(model);
                try
                {
                    var path = ConfigurationManager.AppSettings["PictureServerBasePath"];
                    string filename = Path.GetFileName(model.File.FileName);
                    if (filename != null)
                    {
                        model.FileName = filename;
                        model.File.SaveAs(Path.Combine(path, filename));
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("File", ex.Message);
                }
            }
          
            return ModelState.IsValid;
        }

        private bool DeleteFile(PictureFormModel model)
        {
            if (!string.IsNullOrEmpty(model.FileName) )
            {
                try
                {
                    var path = ConfigurationManager.AppSettings["PictureServerBasePath"];
                    System.IO.File.Delete(Path.Combine(path, model.FileName));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return ModelState.IsValid;
        }

        private bool Validate(PictureFormModel model)
        {
            if (string.IsNullOrEmpty(model.Link) && (model.File == null && string.IsNullOrEmpty(model.FileName)))
                ModelState.AddModelError(string.Empty, Messages.PictureLinkOrFileRequired);

            return ModelState.IsValid;
        }
    }
}