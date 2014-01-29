// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DateTimeExtensions.cs" company="ip-connect GmbH">
//   Copyright (c) ip-connect GmbH. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Lbk.MobileApp.Core.Extensions
{
    using System;
    using System.Globalization;

    /// <summary>
    ///   TODO: Update summary.
    /// </summary>
    public static class DateTimeExtensions
    {
        public static int Iso8601WeekOfYear(this DateTime date)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            var day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                date = date.AddDays(3);
            }

            var result = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            return result;
        }

        public static int YearForIso8601Week(this DateTime date)
        {
            var year = date.Year;
            var weekOfYear = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(
                date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            var endOfYear = new DateTime(year, 12, 31);

            if (weekOfYear == 53 && endOfYear.DayOfWeek < DayOfWeek.Thursday)
            {
                year += 1;
            } 
            return year;
        }
    }
}