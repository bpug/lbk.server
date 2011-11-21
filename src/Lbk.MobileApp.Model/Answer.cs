// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Answer.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model
{
    public class Answer : BaseEntity
    {
        #region - Properties -

        public string Description { get; set; }

        public string Explanation { get; set; }

        public bool IsRight { get; set; }

        public Question Question { get; set; }

        public long QuestionId { get; set; }

        #endregion
    }
}
