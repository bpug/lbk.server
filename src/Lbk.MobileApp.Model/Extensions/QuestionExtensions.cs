// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuestionExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model.Extensions
{
    public static class QuestionExtensions
    {
        #region - Public Methods -

        public static Question GetValueOrDefault(this Question item)
        {
            if (item == null
                ||
                (string.IsNullOrWhiteSpace(item.Description) && item.Number <= 0 && item.Points <= 0
                 && item.SerieId <= 0))
            {
                return null;
            }

            return item;
        }

        #endregion
    }
}
