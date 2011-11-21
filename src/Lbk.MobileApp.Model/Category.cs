// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Category.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model
{
    #region using directives

    using System.Collections.Generic;

    #endregion

    public class Category : BaseEntity
    {
        #region - Constructors and Destructors -

        public Category()
        {
            this.Foods = new List<Food>();
        }

        #endregion

        #region - Properties -

        public string Description { get; set; }

        public ICollection<Food> Foods { get; set; }

        public string Title { get; set; }

        #endregion
    }
}
