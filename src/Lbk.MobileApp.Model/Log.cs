// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Model
{
    using System;

    /// <summary>
    ///   TODO: Update summary.
    /// </summary>
    public class Log
    {
        public string Fingerprint { get; set; }

        public int Id { get; set; }

        public DateTime InsertTime { get; set; }


        public int LogId { get; set; }

        public LogType Type { get; set; }
    }
}