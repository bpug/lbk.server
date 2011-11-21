// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Menu.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model
{
    #region using directives

    using System;
    using System.Collections.Generic;

    #endregion

    public class Menu : BaseEntity
    {
        #region - Constructors and Destructors -

        public Menu()
        {
            this.Foods = new List<Food>();
        }

        #endregion

        #region - Properties -

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public ICollection<Food> Foods { get; set; }

        #endregion
    }
}
