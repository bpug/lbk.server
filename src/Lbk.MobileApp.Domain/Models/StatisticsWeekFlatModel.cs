// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticsWeekFlatModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Domain.Models
{
    using System;

    using Lbk.MobileApp.Core.Extensions;
    using Lbk.MobileApp.Model.Attributes;

    /// <summary>
    ///   TODO: Update summary.
    /// </summary>
    public class StatisticsWeekFlatModel
    {
        [ExportColumn(Name = "Bilder abgerufen", Order = 3)]
        public int Bilder { get; set; }

        [ExportColumn(Name = "Events abgerufen", Order = 4)]
        public int Events { get; set; }

        [ExportColumn(Export = false)]
        public DateTime FirstDateOfWeek
        {
            get
            {
                return DateTimeExtensions.FirstDateOfIsoWeek(this.Year, this.Week);
            }
        }

        [ExportColumn(Name = "Gesamt", Order = 10)]
        public int Gesamt
        {
            get
            {
                return this.Events + this.Quiz + this.Reservierung + this.ReservierungGast + this.Tageskarte
                       + this.Videos + this.Bilder;
            }
        }

        [ExportColumn(Export = false)]
        public DateTime LasrDateOfWeek
        {
            get
            {
                return this.FirstDateOfWeek.AddDays(6);
            }
        }

        [ExportColumn(Name = "Quiz gestartet", Order = 5)]
        public int Quiz { get; set; }

         [ExportColumn(Name = "Reservierung angefragt", Order = 8)]
        public int Reservierung { get; set; }

         [ExportColumn(Name = "Reservierung vom Gast bestätigt", Order = 9)]
        public int ReservierungGast { get; set; }

        [ExportColumn(Name = "Tageskarte abgerufen", Order = 6)]
        public int Tageskarte { get; set; }

        [ExportColumn(Name = "Videos abgerufen", Order = 7)]
        public int Videos { get; set; }

        [ExportColumn(Name = "KW", Order = 2)]
        public int Week { get; set; }

        [ExportColumn(Name = "Jahr", Order = 1)]
        public int Year { get; set; }
    }
}