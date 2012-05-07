// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryController.cs" company="ip-connect GmbH">
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

    public class CategoryController : AuthorizedController
    {
        #region - Constructors and Destructors -

        public CategoryController(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        #endregion

        #region - Public Methods -

        [HttpPost]
        public ActionResult Create(long menuId, CategoryFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<AddCategory>().Execute(model);

                return this.RedirectToAction("List", new { MenuId = menuId });
            }

            return this.View(model);
        }

        public ActionResult Create(long menuId)
        {
            this.ViewBag.MenuId = menuId;

            return this.View();
        }

        public ActionResult Delete(long menuId, long id)
        {
            this.ViewBag.MenuId = menuId;

            var category = this.Using<GetCategoryById>().Execute(id);

            return this.View(category.ToFormModel());
        }

        [HttpPost]
        public ActionResult Delete(long menuId, long id, object dummy)
        {
            this.Using<DeleteCategoryById>().Execute(id);

            return this.RedirectToAction("List", new { MenuId = menuId });
        }

        public ActionResult Detail(long menuId, long id)
        {
            this.ViewBag.MenuId = menuId;

            var category = this.Using<GetCategoryById>().Execute(id);

            return this.View(category.ToFormModel());
        }

        [HttpPost]
        public ActionResult Edit(long menuId, CategoryFormModel model)
        {
            this.ViewBag.MenuId = menuId;

            if (model != null && this.ModelState.IsValid)
            {
                this.Using<UpdateCategory>().Execute(model);

                return this.RedirectToAction("List", new { MenuId = menuId });
            }

            return this.View(model);
        }

        public ActionResult Edit(long menuId, long id)
        {
            this.ViewBag.MenuId = menuId;

            var category = this.Using<GetCategoryById>().Execute(id);

            return this.View(category.ToFormModel());
        }

        public ActionResult List(long menuId, CategorySearchFormModel category, PagedDataInput pagedDataInput, string btnSubmit)
        {
            var menu = this.Using<GetMenuById>().Execute(menuId);
            this.ViewBag.MenuId = menu.Id;
            this.ViewBag.MenuDescription = menu.Description;

            var pagedDataInputOfCategory = new PagedDataInput<Category>(pagedDataInput);
            pagedDataInputOfCategory.PageSize =
                (int)
                this.GetItemFromTempData(
                    pagedDataInputOfCategory.PageSize as object, defaultValue: 10, nullValue: 0, keyName: "PageSize");
            pagedDataInputOfCategory.SearchItem =
                this.GetItemFromTempData(
                    category.GetValueOrDefault().ToModel(), 
                    keyPrefix: "SearchItem_", 
                    removeValue: btnSubmit == Messages.Clear);

            var categories = this.Using<GetCategories>().Execute(pagedDataInputOfCategory);

            var viewModel = new GenericListViewModel<Category, CategorySearchFormModel>();
            viewModel.Results = categories;
            viewModel.SearchItem = btnSubmit == Messages.Clear
                                       ? new CategorySearchFormModel()
                                       : pagedDataInputOfCategory.SearchItem.ToSearchFormModel()
                                         ?? category;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion
    }
}
