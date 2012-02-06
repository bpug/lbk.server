// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Picture.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model
{
    public class Picture : BaseEntity
    {
        #region - Properties -

        public string Description { get; set; }

        public string FileName { get; set; }

        public string Link { get; set; }

        public int SortOrder { get; set; }

        #endregion
    }
}
