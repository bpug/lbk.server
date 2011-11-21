// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionSearchFormModelExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Web.Models.Extensions
{
    #region using directives

    using Lbk.MobileApp.Model;

    #endregion

    public static class QuestionSearchFormModelExtensions
    {
        #region - Public Methods -

        public static QuestionSearchFormModel GetValueOrDefault(this QuestionSearchFormModel item)
        {
            if (item == null
                ||
                (string.IsNullOrWhiteSpace(item.Description) && (!item.Number.HasValue || item.Number <= 0)
                 && (!item.Points.HasValue || item.Points <= 0)))
            {
                return null;
            }

            return item;
        }

        public static QuestionFormModel ToFormModel(Question model)
        {
            if (model == null)
            {
                return null;
            }

            return new QuestionFormModel
                {
                    Id = model.Id, 
                    Description = model.Description, 
                    Number = model.Number, 
                    Points = model.Points, 
                    SerieId = model.SerieId
                };
        }

        public static Question ToModel(QuestionSearchFormModel model)
        {
            if (model == null)
            {
                return null;
            }

            return new Question
                {
                    Id = model.Id, 
                    Description = model.Description, 
                    Number = model.Number.HasValue ? model.Number.Value : 0, 
                    Points = model.Points.HasValue ? model.Points.Value : 0, 
                    SerieId = model.SerieId
                };
        }

        public static QuestionSearchFormModel ToSearchFormModel(Question model)
        {
            if (model == null)
            {
                return null;
            }

            return new QuestionSearchFormModel
                {
                    Id = model.Id, 
                    Description = model.Description, 
                    Number = model.Number > 0 ? model.Number : new int?(), 
                    Points = model.Points > 0 ? model.Points : new int?(), 
                    SerieId = model.SerieId
                };
        }

        #endregion
    }
}
