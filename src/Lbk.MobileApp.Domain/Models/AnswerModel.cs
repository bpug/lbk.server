// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnswerModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Domain.Models
{
    public class AnswerModel : BaseModel
    {
        #region - Properties -

        public string Description { get; set; }

        public string Explanation { get; set; }

        public bool IsRight { get; set; }

        public long QuestionId { get; set; }

        #endregion
    }
}
