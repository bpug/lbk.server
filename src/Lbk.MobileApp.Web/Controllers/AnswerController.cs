// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerController.cs" company="ip-connect GmbH">
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

    public partial class AnswerController : AuthorizedController
    {
        #region - Constructors and Destructors -

        public AnswerController(IServiceLocator serviceLocator)
            : base(serviceLocator)
        {
        }

        #endregion

        #region - Public Methods -

        [HttpPost]
        public virtual ActionResult Create(long questionId, AnswerFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<AddAnswer>().Execute(questionId, model);

                return this.RedirectToAction("List", new { id = questionId });
            }

            return this.View(model);
        }

        public virtual ActionResult Create(long id)
        {
            return this.View(new AnswerFormModel { QuestionId = id });
        }

        public virtual ActionResult Delete(long id)
        {
            var answer = this.Using<GetAnswerById>().Execute(id);

            return this.View(answer.ToFormModel());
        }

        [HttpPost]
        public virtual ActionResult Delete(long id, long questionId)
        {
            this.Using<DeleteAnswerById>().Execute(id);

            return this.RedirectToAction("List", new { id = questionId });
        }

        public virtual ActionResult Detail(long id)
        {
            var answer = this.Using<GetAnswerById>().Execute(id);

            return this.View(answer.ToFormModel());
        }

        [HttpPost]
        public virtual ActionResult Edit(AnswerFormModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                this.Using<UpdateAnswer>().Execute(model);

                return this.RedirectToAction("List", new { id = model.QuestionId });
            }

            return this.View(model);
        }

        public virtual ActionResult Edit(long id)
        {
            var answer = this.Using<GetAnswerById>().Execute(id);

            return this.View(answer.ToFormModel());
        }

        public virtual ActionResult List(long id, AnswerSearchFormModel answer, PagedDataInput pagedDataInput, string btnSubmit)
        {
            var question = this.Using<GetQuestionById>().Execute(id);
            this.ViewBag.QuestionId = question.Id;
            this.ViewBag.QuestionDescription = question.Description;
            var serie = this.Using<GetSerieById>().Execute(question.SerieId);
            this.ViewBag.SerieId = serie.Id;
            this.ViewBag.SerieDescription = serie.Description;

            answer.QuestionId = id;

            var pagedDataInputOfQuestion = new PagedDataInput<Answer>(pagedDataInput);
            pagedDataInputOfQuestion.PageSize =
                (int)
                this.GetItemFromTempData(
                    pagedDataInputOfQuestion.PageSize as object, defaultValue: 10, nullValue: 0, keyName: "PageSize");
            pagedDataInputOfQuestion.SearchItem =
                this.GetItemFromTempData(
                    answer.GetValueOrDefault().ToModel(), 
                    defaultValue: new Answer { QuestionId = id },
                    keyPrefix: "SearchItem_" + id,
                    removeValue: btnSubmit == Messages.Clear);

            var answers = this.Using<GetAnswers>().Execute(pagedDataInputOfQuestion);

            var viewModel = new GenericListViewModel<Answer, AnswerSearchFormModel>();
            viewModel.Results = answers;
            viewModel.SearchItem = btnSubmit == Messages.Clear
                                       ? new AnswerSearchFormModel()
                                       : pagedDataInputOfQuestion.SearchItem.ToSearchFormModel() ?? answer;

            if (this.Request.IsAjaxRequest())
            {
                return this.PartialView("_search", viewModel);
            }

            return this.View(viewModel);
        }

        #endregion
    }
}
