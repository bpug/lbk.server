// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerSearchFormModelExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using Lbk.MobileApp.Model;

    #endregion

    public static class AnswerSearchFormModelExtensions
    {
        #region - Public Methods -

        public static AnswerSearchFormModel GetValueOrDefault(this AnswerSearchFormModel item)
        {
            if (item == null
                || (string.IsNullOrWhiteSpace(item.Description) && string.IsNullOrWhiteSpace(item.Explanation)))
            {
                return null;
            }

            return item;
        }

        public static AnswerFormModel ToFormModel(Answer model)
        {
            if (model == null)
            {
                return null;
            }

            return new AnswerFormModel
                {
                    Id = model.Id, 
                    Description = model.Description, 
                    Explanation = model.Explanation, 
                    IsRight = model.IsRight, 
                    QuestionId = model.QuestionId
                };
        }

        public static Answer ToModel(AnswerSearchFormModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Answer
                {
                    Id = model.Id, 
                    Description = model.Description, 
                    Explanation = model.Explanation, 
                    QuestionId = model.QuestionId
                };
        }

        public static AnswerSearchFormModel ToSearchFormModel(Answer model)
        {
            if (model == null)
            {
                return null;
            }

            return new AnswerSearchFormModel
                {
                    Id = model.Id, 
                    Description = model.Description, 
                    Explanation = model.Explanation, 
                    QuestionId = model.QuestionId
                };
        }

        #endregion
    }
}
