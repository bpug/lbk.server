// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionController.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
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

    public class QuestionController : AuthorizedController
    {
        #region - Constructors and Destructors -

        public QuestionController(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        #endregion

        #region - Public Methods -

        [HttpPost]
        public ActionResult Create(long serieId, long categoryId, QuestionFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<AddQuestion>().Execute(serieId, categoryId, model);

                return this.RedirectToAction("List", new { controller = "Answer", id = model.Id });
            }

            return this.View(model);
        }

        public ActionResult Create(long id)
        {
            this.AddCategorySelectListToViewData();
            return this.View(new QuestionFormModel { SerieId = id });
        }

        public ActionResult Delete(long id)
        {
            var question = this.Using<GetQuestionById>().Execute(id);

            return this.View(question.ToFormModel());
        }

        [HttpPost]
        public ActionResult Delete(long id, long serieId)
        {
            this.Using<DeleteQuestionById>().Execute(id);

            return this.RedirectToAction("List", new { id = serieId });
        }

        public ActionResult Detail(long id)
        {
            var question = this.Using<GetQuestionById>().Execute(id);

            return this.View(question.ToFormModel());
        }

        [HttpPost]
        public ActionResult Edit(QuestionFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<UpdateQuestion>().Execute(model);

                return this.RedirectToAction("List", new { id = model.SerieId });
            }

            return this.View(model);
        }

        public ActionResult Edit(long id)
        {
            var question = this.Using<GetQuestionById>().Execute(id);

            this.AddCategorySelectListToViewData(question.ToFormModel());

            return this.View(question.ToFormModel());
        }

        public ActionResult List(
            long id, QuestionSearchFormModel question, PagedDataInput pagedDataInput, string btnSubmit)
        {
            var serie = this.Using<GetSerieById>().Execute(id);
            this.ViewBag.SerieId = serie.Id;
            this.ViewBag.SerieDescription = serie.Description;

            question.SerieId = id;

            var pagedDataInputOfQuestion = new PagedDataInput<Question>(pagedDataInput);
            pagedDataInputOfQuestion.PageSize =
                (int)
                this.GetItemFromTempData(
                    pagedDataInputOfQuestion.PageSize as object, defaultValue: 10, nullValue: 0, keyName: "PageSize");
            pagedDataInputOfQuestion.SearchItem =
                this.GetItemFromTempData(
                    question.GetValueOrDefault().ToModel(), 
                    defaultValue: new Question { SerieId = id }, 
                    keyPrefix: "SearchItem_" + id, 
                    removeValue: btnSubmit == Messages.Clear);

            var questions = this.Using<GetQuestions>().Execute(pagedDataInputOfQuestion);

            var viewModel = new GenericListViewModel<Question, QuestionSearchFormModel>();
            viewModel.Results = questions;
            viewModel.SearchItem = btnSubmit == Messages.Clear
                                       ? new QuestionSearchFormModel()
                                       : pagedDataInputOfQuestion.SearchItem.ToSearchFormModel() ?? question;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion

        #region - Methods -
        private void AddCategorySelectListToViewData(QuestionFormModel model = null)
        {
            var categories =
                this.Using<GetQuestionCategories>().Execute(
                    new PagedDataInput<QuestionCategory> { Ascending = true, PageIndex = 0, PageSize = 1000 });
           
            this.ViewData["Categories"] =
                new SelectList(
                    categories.Select(x => new { Value = x.Id, Text = x.GetCategoryCompleteDescription() }),
                    "Value",
                    "Text",
                    (model != null) ? model.CategoryId : 0);
        }

        #endregion
    }
}
