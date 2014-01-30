// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExportColumnAttribute.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Lbk.MobileApp.Model.Attributes
{
    using System;

    public class ExportColumnAttribute : Attribute
    {
        public ExportColumnAttribute()
        {
            this.Export = true;
            this.Order = int.MaxValue;
        }

        public bool Export { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}