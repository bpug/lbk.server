// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Lbk.MobileApp.Web.Extensions;

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

    public class MenuController : AuthorizedController
    {
        #region - Constructors and Destructors -

        public MenuController(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        #endregion

        #region - Public Methods -

        public ActionResult Copy(long id)
        {
            var menu = this.Using<GetMenuById>().Execute(id);

            return this.View(MenuSearchFormModelExtensions.ToFormModel(menu));
        }

        [HttpPost]
        public ActionResult Copy(MenuFormModel model)
        {
            this.Using<CopyMenu>().Execute(model);

            return this.RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Create(MenuFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<AddMenu>().Execute(model);

                return this.RedirectToAction("List", new { controller = "Food", id = model.Id });
            }

            return this.View(model);
        }

        public ActionResult Create()
        {
            return this.View(new MenuFormModel { Date = DateTime.Now });
        }

        public ActionResult Delete(long id)
        {
            var menu = this.Using<GetMenuById>().Execute(id);

            return this.View(MenuSearchFormModelExtensions.ToFormModel(menu));
        }

        [HttpPost]
        public ActionResult Delete(long id, object dummy)
        {
            this.Using<DeleteMenuById>().Execute(id);

            return this.RedirectToAction("List");
        }

        public ActionResult Detail(long id)
        {
            var menu = this.Using<GetMenuById>().Execute(id);

            return this.View(MenuSearchFormModelExtensions.ToFormModel(menu));
        }

        [HttpPost]
        public ActionResult Edit(MenuFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<UpdateMenu>().Execute(model);

                return this.RedirectToAction("List");
            }

            return this.View(model);
        }

        public ActionResult Edit(long id)
        {
            var menu = this.Using<GetMenuById>().Execute(id);

            return this.View(MenuSearchFormModelExtensions.ToFormModel(menu));
        }

        public ActionResult List(MenuSearchFormModel menu, PagedDataInput pagedDataInput, string btnSubmit)
        {
            //ColumnNormalizer.
            var pagedDataInputOfMenu = new PagedDataInput<Menu>(pagedDataInput);
            pagedDataInputOfMenu.PageSize =
                (int)
                this.GetItemFromTempData(
                    pagedDataInputOfMenu.PageSize as object, defaultValue: 10, nullValue: 0, keyName: "PageSize");
            pagedDataInputOfMenu.SearchItem =
                this.GetItemFromTempData(
                    MenuSearchFormModelExtensions.ToModel(menu.GetValueOrDefault()), 
                    keyPrefix: "SearchItem_", 
                    removeValue: btnSubmit == "Clear");
            pagedDataInputOfMenu.Sort = pagedDataInputOfMenu.Sort.GetValueOrDefault("Date");
            pagedDataInputOfMenu.SortDir = pagedDataInputOfMenu.SortDir.GetValueOrDefault("desc"); ;

            var series = this.Using<GetMenus>().Execute(pagedDataInputOfMenu);

            var viewModel = new GenericListViewModel<Menu, MenuSearchFormModel>();
            viewModel.Results = series;
            viewModel.SearchItem = btnSubmit == "Clear"
                                       ? new MenuSearchFormModel()
                                       : MenuSearchFormModelExtensions.ToSearchFormModel(
                                           pagedDataInputOfMenu.SearchItem) ?? menu;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion

        #region - Methods -
        //private static string FixupMenuSortColumn(string sort)
        //{
        //    if (string.IsNullOrWhiteSpace(sort))
        //    {
        //        return "Date";
        //    }
        //    return sort;
        //}

        //private static string FixupMenuSortDir(string sortDir)
        //{
        //    if (string.IsNullOrWhiteSpace(sortDir))
        //    {
        //        return "desc";
        //    }
        //    return sortDir;
        //}
        #endregion
    }
}
