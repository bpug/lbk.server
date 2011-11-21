// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Serie.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model
{
    #region using directives

    using System;
    using System.Collections.Generic;

    #endregion

    public class Serie : BaseEntity
    {
        #region - Constructors and Destructors -

        public Serie()
        {
            this.Questions = new List<Question>();
        }

        #endregion

        #region - Properties -

        public DateTime ActivatedAt { get; set; }

        public string Description { get; set; }

        public DateTime ExpiresAt { get; set; }

        public bool IsActivated { get; set; }

        public ICollection<Question> Questions { get; set; }

        #endregion
    }
}
