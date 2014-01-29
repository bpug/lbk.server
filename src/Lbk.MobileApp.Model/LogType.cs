// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogType.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Model
{
    using System.Collections.Generic;

    /// <summary>
    ///   TODO: Update summary.
    /// </summary>
    public class LogType
    {
        public string Description { get; set; }

        public int Id { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}