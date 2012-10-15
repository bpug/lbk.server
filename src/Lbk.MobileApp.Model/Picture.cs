// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Picture.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Lbk.MobileApp.Model.Attributes;

namespace Lbk.MobileApp.Model
{
    public class Picture : BaseEntity
    {
        #region - Properties -

        [Translate(true)]
        public string Title { get; set; }

        [Translate(true)]
        public string Description { get; set; }

        public string FileName { get; set; }

        public string Link { get; set; }

        public int SortOrder { get; set; }

        #endregion
    }
}
