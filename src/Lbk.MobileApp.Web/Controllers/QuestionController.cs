// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionController.cs" company="ip-connect GmbH">
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
        public ActionResult Create(long serieId, QuestionFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<AddQuestion>().Execute(serieId, model);

                return this.RedirectToAction("List", new { controller = "Answer", id = model.Id });
            }

            return this.View(model);
        }

        public ActionResult Create(long id)
        {
            return this.View(new QuestionFormModel { SerieId = id });
        }

        public ActionResult Delete(long id)
        {
            var question = this.Using<GetQuestionById>().Execute(id);

            return this.View(QuestionSearchFormModelExtensions.ToFormModel(question));
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

            return this.View(QuestionSearchFormModelExtensions.ToFormModel(question));
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

            return this.View(QuestionSearchFormModelExtensions.ToFormModel(question));
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
                    QuestionSearchFormModelExtensions.ToModel(question.GetValueOrDefault()), 
                    defaultValue: new Question { SerieId = id }, 
                    keyPrefix: "SearchItem_" + id, 
                    removeValue: btnSubmit == "Clear");

            var questions = this.Using<GetQuestions>().Execute(pagedDataInputOfQuestion);

            var viewModel = new GenericListViewModel<Question, QuestionSearchFormModel>();
            viewModel.Results = questions;
            viewModel.SearchItem = btnSubmit == "Clear"
                                       ? new QuestionSearchFormModel()
                                       : QuestionSearchFormModelExtensions.ToSearchFormModel(
                                           pagedDataInputOfQuestion.SearchItem) ?? question;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion
    }
}
