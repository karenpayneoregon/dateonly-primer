namespace WorkingWithDateOnly.Classes
{
    public static class DateTimeMethods
    {
        public static DateTime Next(this DateTime from, DayOfWeek dayOfWeek)
        {
            int start = (int)from.DayOfWeek;
            int target = (int)dayOfWeek;
            if (target <= start)
            {
                target += 7;
            }

            return from.AddDays(target - start);
        }

        public static List<DateTime> NextWeeksDates() =>
            Enumerable.Range(0, 7).Select(index =>
                DateTime.Now.Next(DayOfWeek.Sunday).AddDays(index)).ToList();

        public static List<DateTime> GetMonthDays(int month)
        {
            var year = DateTime.Now.Year;

            return Enumerable.Range(1, DateTime.DaysInMonth(year, month))
                .Select(day => new DateTime(year, month, day))
                .ToList();
        }

        /// <summary>
        /// Get Month name by month index
        /// </summary>
        public static string MonthName
            => CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month);
    }

}
