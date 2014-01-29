// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatisticsWeekFlatModel.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Domain.Models
{
    /// <summary>
    ///   TODO: Update summary.
    /// </summary>
    public class StatisticsWeekFlatModel
    {
        public int Bilder { get; set; }

        public int Events { get; set; }

        public int Gesamt
        {
            get
            {
                return this.Events + this.Quiz + this.Reservierung + this.ReservierungGast + this.Tageskarte
                       + this.Videos + this.Week;
            }
        }

        public int Quiz { get; set; }

        public int Reservierung { get; set; }

        public int ReservierungGast { get; set; }

        public int Tageskarte { get; set; }

        public int Videos { get; set; }

        public int Week { get; set; }

        public int Year { get; set; }
    }
}