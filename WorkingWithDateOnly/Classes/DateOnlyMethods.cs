namespace WorkingWithDateOnly.Classes
{
    public static class DateOnlyMethods
    {
        /// <summary>
        /// Get dates for the coming week
        /// </summary>
        /// <returns></returns>
        public static List<DateOnly> NextWeeksDates()
            => Enumerable.Range(0, 7).Select(index =>
                    DateOnly.FromDateTime(DateTime.Now).Next(DayOfWeek.Sunday).AddDays(index))
                .ToList();

        /// <summary>
        /// Helper for <see cref="NextWeeksDates"/>
        /// </summary>
        /// <param name="from"></param>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public static DateOnly Next(this DateOnly from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;

            if (target <= start)
            {
                target += 7;
            }

            return from.AddDays(target - start);
        }

        /// <summary>
        /// Get all days in month as <see cref="DateOnly"/> list
        /// </summary>
        /// <param name="month">Month index</param>
        /// <returns>list of date only for given month</returns>
        public static List<DateOnly> GetMonthDays(int month)
        {
            var year = DateTime.Now.Year;

            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                .Select(day => new DateOnly(year, month, day))
                .ToList();
        }

        /// <summary>
        /// Get Month name by month index
        /// </summary>
        public static string MonthName
            => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
    }
}
