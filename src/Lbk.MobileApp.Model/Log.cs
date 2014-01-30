﻿// --------------------------------------------------------------------------------------------------------------------
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

        public int LogEventId { get; set; }

        public LogEvent Event { get; set; }
    }
}