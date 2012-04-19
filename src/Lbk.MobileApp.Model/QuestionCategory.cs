// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Question.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model
{
    #region using directives

    #endregion

    public class QuestionCategory : BaseEntity
    {

        #region - Properties -

        public string Title { get; set; }

        #endregion

        public override string ToString()
        {
            return Title;
        }
    }
}
