// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Food.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model
{
    public class Food : BaseEntity
    {
        #region - Properties -

        public Category Category { get; set; }

        public long CategoryId { get; set; }

        public string Description { get; set; }

        public Menu Menu { get; set; }

        public long MenuId { get; set; }

        public decimal Price { get; set; }

        public int SortOrder { get; set; }

        public string Title { get; set; }

        #endregion
    }
}
