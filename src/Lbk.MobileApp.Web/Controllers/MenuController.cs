// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuController.cs" company="ip-connect GmbH">
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

    public class MenuController : AuthorizedController
    {
        #region - Constructors and Destructors -

        public MenuController(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        #endregion

        #region - Public Methods -

        public ActionResult List(MenuSearchFormModel menu, PagedDataInput pagedDataInput, string btnSubmit)
        {
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
    }
}
