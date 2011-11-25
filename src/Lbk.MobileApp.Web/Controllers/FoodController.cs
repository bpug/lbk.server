// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FoodController.cs" company="ip-connect GmbH">
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

    public class FoodController : AuthorizedController
    {
        #region - Constructors and Destructors -

        public FoodController(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        #endregion

        #region - Public Methods -

        public ActionResult List(long id, FoodSearchFormModel question, PagedDataInput pagedDataInput, string btnSubmit)
        {
            var menu = this.Using<GetMenuById>().Execute(id);
            this.ViewBag.MenuId = menu.Id;
            this.ViewBag.MenuDescription = menu.Description;

            question.MenuId = id;

            var pagedDataInputOfFoods = new PagedDataInput<Food>(pagedDataInput);
            pagedDataInputOfFoods.PageSize =
                (int)
                this.GetItemFromTempData(
                    pagedDataInputOfFoods.PageSize as object, defaultValue: 10, nullValue: 0, keyName: "PageSize");
            pagedDataInputOfFoods.SearchItem =
                this.GetItemFromTempData(
                    FoodSearchFormModelExtensions.ToModel(question.GetValueOrDefault()), 
                    defaultValue: new Food { MenuId = id }, 
                    keyPrefix: "SearchItem_" + id, 
                    removeValue: btnSubmit == "Clear");

            var foods = this.Using<GetFoods>().Execute(pagedDataInputOfFoods);

            var viewModel = new GenericListViewModel<Food, FoodSearchFormModel>();
            viewModel.Results = foods;
            viewModel.SearchItem = btnSubmit == "Clear"
                                       ? new FoodSearchFormModel()
                                       : FoodSearchFormModelExtensions.ToSearchFormModel(
                                           pagedDataInputOfFoods.SearchItem) ?? question;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion
    }
}
