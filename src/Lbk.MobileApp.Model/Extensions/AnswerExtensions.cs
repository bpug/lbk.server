// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model.Extensions
{
    public static class AnswerExtensions
    {
        #region - Public Methods -

        public static Answer GetValueOrDefault(this Answer item)
        {
            if (item == null
                ||
                (string.IsNullOrWhiteSpace(item.Description) && string.IsNullOrWhiteSpace(item.Explanation)
                 && item.QuestionId <= 0))
            {
                return null;
            }

            return item;
        }

        #endregion
    }
}
