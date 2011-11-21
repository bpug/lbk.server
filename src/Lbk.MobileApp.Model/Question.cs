// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Question.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model
{
    #region using directives

    using System.Collections.Generic;

    #endregion

    public class Question : BaseEntity
    {
        #region - Constructors and Destructors -

        public Question()
        {
            this.Answers = new List<Answer>();
        }

        #endregion

        #region - Properties -

        public ICollection<Answer> Answers { get; set; }

        public string Description { get; set; }

        public int Number { get; set; }

        public int Points { get; set; }

        public Serie Serie { get; set; }

        public long SerieId { get; set; }

        #endregion
    }
}
